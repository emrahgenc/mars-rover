using MarsRoger.Client.ApiClients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarsRoger.Client
{
    class Program
    {
        public static IConfiguration configuration;
        private static IMarsRoverApiClient marsRoverApiClient;

        static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            marsRoverApiClient = serviceProvider.GetRequiredService<IMarsRoverApiClient>();

            while (true)
            {
                try
                {
                    var plateauId = await PreparePlateau();
                    var roverId = await LandRoverToPlateau(plateauId);
                    await ChangeRoverPosition(roverId);

                    await GetRoverPosition(roverId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static async Task GetRoverPosition(Guid roverId)
        {
            var position = await marsRoverApiClient.GetPositionAsync(roverId);
            Console.WriteLine("The last position of rover is:");
            Console.WriteLine($"{position.Coordinate.X} {position.Coordinate.Y} {position.Direction.ToString()[0]}");

            Console.ReadLine();
        }

        private static async Task ChangeRoverPosition(Guid roverId)
        {
            Console.WriteLine("Please Enter Rover Movement Codes (Allowed Letters: 'L R M'):");
            var roverPosition = Console.ReadLine().Replace(" ", "").ToUpper();

            if (new Regex(@"^([MRLmrl])+$").Match(roverPosition).Success)
            {
                foreach (var positionLetter in roverPosition)
                {
                    switch (positionLetter)
                    {
                        case 'L':
                            await marsRoverApiClient.TurnLeftRoverAsync(roverId, new TurnLeftRoverRequest
                            {
                                RoverId = roverId
                            });
                            break;
                        case 'R':
                            await marsRoverApiClient.TurnRightRoverAsync(roverId, new TurnRightRoverRequest
                            {
                                RoverId = roverId
                            });
                            break;
                        case 'M':
                            await marsRoverApiClient.MoveRoverAsync(roverId, new MoveRoverRequest
                            {
                                RoverId = roverId
                            });
                            break;
                    }
                }
                return;
            }

            Console.WriteLine("Command Input entered for movement size are invalid.");
            await ChangeRoverPosition(roverId);
        }

        private static async Task<Guid> LandRoverToPlateau(Guid plateauId)
        {
            Console.WriteLine("Please Enter Rover Landing Info (Input Format: 'X Y D'):");
            var roverPosition = Console.ReadLine().ToUpper();

            if (new Regex(@"^\d+ \d+ [NSEW]$").Match(roverPosition).Success)
            {
                var inputs = roverPosition.Split(' ');
                if (int.TryParse(inputs[0], out int x) && int.TryParse(inputs[1], out int y))
                {
                    var direction = inputs[2];
                    var roverId = await marsRoverApiClient.CreateRoverAsync(new CreateRoverRequest
                    {
                        Code = Guid.NewGuid().ToString()
                    });

                    await marsRoverApiClient.LandRoverToPlateauAsync(roverId, new LandToPlateauRequest
                    {
                        PlateauId = plateauId,
                        RoverId = roverId,
                        Coordinate = new Coordinate
                        {
                            X = x,
                            Y = y
                        },
                        Direction = GetDirection(direction)
                    });

                    return roverId;
                }
            }
            Console.WriteLine("Command Input entered for landing are invalid.");
            return await LandRoverToPlateau(plateauId);
        }

        private static Direction GetDirection(string direction)
        {
            switch (direction)
            {
                case "N":
                    return Direction.North;
                case "W":
                    return Direction.West;
                case "S":
                    return Direction.South;
                case "E":
                    return Direction.East;
                default:
                    throw new ArgumentException("Unknown direction");
            }
        }


        private async static Task<Guid> PreparePlateau()
        {
            Console.WriteLine("Please Enter Plateau Size (Input Format: 'W H'):");
            var plateauSize = Console.ReadLine().ToUpper();

            if (new Regex(@"^\d+ \d+$").Match(plateauSize).Success)
            {
                var inputs = plateauSize.Split(' ');
                if (int.TryParse(inputs[0], out int width) && int.TryParse(inputs[1], out int height))
                {
                    var plateauCode = Guid.NewGuid().ToString();
                    return await marsRoverApiClient.CreatePlateauAsync(new CreatePlateauRequest
                    {
                        Code = plateauCode,
                        Height = height,
                        Width = width
                    });
                }
            }

            Console.WriteLine("Command Input entered for the plateau size are invalid.");
            return await PreparePlateau();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            services.AddTransient<UnsuccessfullResponseDelegatingHandler>();

            string baseAddress = configuration.GetSection("MarsRoverApiBaseAddress").Value;
            services.AddRefitClient<IMarsRoverApiClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseAddress))
                .AddHttpMessageHandler<UnsuccessfullResponseDelegatingHandler>();


        }
    }
}

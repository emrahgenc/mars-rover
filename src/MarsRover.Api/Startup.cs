using FluentValidation.AspNetCore;
using MarsRover.Application.Commands;
using MarsRover.Application.Validators;
using MarsRover.Core.Abstraction.Exceptions;
using MarsRover.Data.EntityFramework.Extensions;
using MarsRover.Infrastructure.Persistancy;
using MarsRover.Infrastructure.Profiles;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

namespace MarsRover.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetSection("ConnectionString").Value;
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDataContext<MarsRoverDbContext>(options =>
                {
                    options.UseSqlServer(connectionString, b => b.MigrationsAssembly(migrationsAssembly));
                })
                .AddEntityFrameworkData();

            services.AddMediatR(typeof(CreatePlateauCommand));
            services.AddAutoMapper(typeof(PlateauProfile));

            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateRoverCommandValidator>())
                .AddJsonOptions(opts =>
                {
                    var enumConverter = new JsonStringEnumConverter();
                    opts.JsonSerializerOptions.Converters.Add(enumConverter);
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MarsRover.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MarsRover.Api v1"));
            }

            app.UseExceptionHandler();

            app.UseRouting();
            app.UseExceptionMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ConfigureMigrations(app);
        }

        private static void ConfigureMigrations(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<MarsRoverDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}

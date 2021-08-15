using Ardalis.GuardClauses;
using MarsRover.Application.Commands;
using MarsRover.Core.Abstraction;
using MarsRover.Core.Abstraction.Data;
using MarsRover.Domain.AggregatesModel.PlateauAggregate;
using MarsRover.Domain.AggregatesModel.RoverAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Application.CommandHandlers
{
    public class LandToPlateauCommandHandler : IRequestHandler<LandToPlateauCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private const string roverAllreadyLandedMessage = "The rover has landed on the planet before.";
        private const string unknownCoordinate = "The rover wants to land in an undefined area.";

        public LandToPlateauCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(LandToPlateauCommand request, CancellationToken cancellationToken)
        {
            var rover = await _unitOfWork.AttachAsync<Rover>(request.RoverId);
            Guard.Against.Null(rover, nameof(rover));

            if (!rover.PlateauId.Equals(default))
            {
                ApplicationContext.ThrowBusinessException($"{roverAllreadyLandedMessage} (#{rover.PlateauId})");
            }

            var plateau = await _unitOfWork.AttachAsync<Plateau>(request.PlateauId);
            Guard.Against.Null(plateau, nameof(plateau));

            if (!plateau.IsValid(request.Coordinate))
            {
                ApplicationContext.ThrowBusinessException(unknownCoordinate);
            }

            var position = new Position(request.Coordinate, request.Direction);
            rover.LandToPlateau(plateau.Id, position);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
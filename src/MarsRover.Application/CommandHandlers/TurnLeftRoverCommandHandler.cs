using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using MarsRover.Application.Commands;
using MarsRover.Core.Abstraction;
using MarsRover.Core.Abstraction.Data;
using MarsRover.Domain.AggregatesModel.PlateauAggregate;
using MarsRover.Domain.AggregatesModel.RoverAggregate;
using MediatR;

namespace MarsRover.Application.CommandHandlers
{
    public class TurnLeftRoverCommandHandler : IRequestHandler<TurnLeftRoverCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private const string roverNotLandedMessage = "The rover has not yet landed on the planet.";

        public TurnLeftRoverCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(TurnLeftRoverCommand request, CancellationToken cancellationToken)
        {
            var rover = await _unitOfWork.AttachAsync<Rover>(request.RoverId);
            Guard.Against.Null(rover, nameof(rover));

            if (rover.PlateauId.Equals(default))
            {
                ApplicationContext.ThrowBusinessException(roverNotLandedMessage);
            }

            var plateau = await _unitOfWork.AttachAsync<Plateau>(rover.PlateauId);
            Guard.Against.Null(plateau, nameof(plateau));

            rover.TurnLeft();

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
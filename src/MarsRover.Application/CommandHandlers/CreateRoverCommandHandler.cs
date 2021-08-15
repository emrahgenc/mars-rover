using MarsRover.Application.Commands;
using MarsRover.Application.Queries;
using MarsRover.Core.Abstraction;
using MarsRover.Core.Abstraction.Data;
using MarsRover.Domain.AggregatesModel.RoverAggregate;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Application.CommandHandlers
{
    public class CreateRoverCommandHandler : IRequestHandler<CreateRoverCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private const string roverAllreadyExistedMessage = "The rover is allready existed";

        public CreateRoverCommandHandler(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }
        public async Task<Guid> Handle(CreateRoverCommand request, CancellationToken cancellationToken)
        {
            var isRoverExists = await _mediator.Send(new CheckRoverByCodeQuery(request.Code), cancellationToken);
            if (isRoverExists)
            {
                ApplicationContext.ThrowBusinessException(roverAllreadyExistedMessage);
            }

            var repository = _unitOfWork.GetRepository<Rover>();

            var rover = new Rover(request.Code);

            await repository.MarkForInsertionAsync(rover, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return rover.Id;
        }
    }
}
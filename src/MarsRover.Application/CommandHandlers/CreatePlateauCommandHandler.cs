using MarsRover.Application.Commands;
using MarsRover.Application.Queries;
using MarsRover.Core.Abstraction;
using MarsRover.Core.Abstraction.Data;
using MarsRover.Domain.AggregatesModel.PlateauAggregate;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Application.CommandHandlers
{
    public class CreatePlateauCommandHandler : IRequestHandler<CreatePlateauCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private const string plateauAllreadyExistedMessage = "The plateau is allready existed";

        public CreatePlateauCommandHandler(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }
        public async Task<Guid> Handle(CreatePlateauCommand request, CancellationToken cancellationToken)
        {
            var isPlateauExists = await _mediator.Send(new CheckPlateauByCodeQuery(request.Code), cancellationToken);
            if (isPlateauExists)
            {
                ApplicationContext.ThrowBusinessException(plateauAllreadyExistedMessage);
            }

            var repository = _unitOfWork.GetRepository<Plateau>();

            var size = new Size(request.Width, request.Height);
            var plateau = new Plateau(request.Code, size);

            await repository.MarkForInsertionAsync(plateau, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return plateau.Id;
        }
    }
}

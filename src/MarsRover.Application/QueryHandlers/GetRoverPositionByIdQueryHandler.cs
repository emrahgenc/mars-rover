using System.Threading;
using System.Threading.Tasks;
using MarsRover.Application.Queries;
using MarsRover.Core.Abstraction.Data;
using MarsRover.Domain.AggregatesModel.RoverAggregate;
using MediatR;

namespace MarsRover.Application.QueryHandlers
{
    public class GetRoverPositionByIdQueryHandler : IRequestHandler<GetRoverPositionByIdQuery, Position>
    {
        private readonly IQuery<Rover> _query;

        public GetRoverPositionByIdQueryHandler(IQuery<Rover> query)
        {
            _query = query;
        }
        public async Task<Position> Handle(GetRoverPositionByIdQuery request, CancellationToken cancellationToken)
        {
            var rover = await _query.SingleOrDefaultAsync(p => p.Id == request.Id);
            return rover?.Position;
        }
    }
}
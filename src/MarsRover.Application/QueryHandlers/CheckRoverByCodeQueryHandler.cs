using MarsRover.Application.Queries;
using MarsRover.Core.Abstraction.Data;
using MarsRover.Domain.AggregatesModel.RoverAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Application.QueryHandlers
{
    public class CheckRoverByCodeQueryHandler : IRequestHandler<CheckRoverByCodeQuery, bool>
    {
        private readonly IQuery<Rover> _query;

        public CheckRoverByCodeQueryHandler(IQuery<Rover> query)
        {
            _query = query;
        }
        public async Task<bool> Handle(CheckRoverByCodeQuery request, CancellationToken cancellationToken)
        {
            return await _query.AnyAsync(p => p.Code == request.Code);
        }
    }
}
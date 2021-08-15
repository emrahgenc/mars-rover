using MarsRover.Application.Queries;
using MarsRover.Core.Abstraction.Data;
using MarsRover.Domain.AggregatesModel.PlateauAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Application.QueryHandlers
{
    public class CheckPlateauByCodeQueryHandler : IRequestHandler<CheckPlateauByCodeQuery, bool>
    {
        private readonly IQuery<Plateau> _query;

        public CheckPlateauByCodeQueryHandler(IQuery<Plateau> query)
        {
            _query = query;
        }
        public async Task<bool> Handle(CheckPlateauByCodeQuery request, CancellationToken cancellationToken)
        {
            return await _query.AnyAsync(p => p.Code == request.Code);
        }
    }
}

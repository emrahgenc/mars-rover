using MarsRover.Application.Queries;
using MarsRover.Core.Abstraction.Data;
using MarsRover.Domain.AggregatesModel.PlateauAggregate;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Application.QueryHandlers
{
    public class GetAllPlateausQueryHandler : IRequestHandler<GetAllPlateausQuery, List<Plateau>>
    {
        private readonly IQuery<Plateau> _query;

        public GetAllPlateausQueryHandler(IQuery<Plateau> query)
        {
            _query = query;
        }
        public async Task<List<Plateau>> Handle(GetAllPlateausQuery request, CancellationToken cancellationToken)
        {
            return await _query.GetAllAsync(cancellationToken);
        }
    }
}
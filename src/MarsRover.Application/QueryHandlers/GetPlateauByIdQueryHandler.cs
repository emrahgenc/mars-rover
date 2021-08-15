using MarsRover.Application.Queries;
using MarsRover.Core.Abstraction.Data;
using MarsRover.Domain.AggregatesModel.PlateauAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Application.QueryHandlers
{
    public class GetPlateauByIdQueryHandler : IRequestHandler<GetPlateauByIdQuery, Plateau>
    {
        private readonly IQuery<Plateau> _query;

        public GetPlateauByIdQueryHandler(IQuery<Plateau> query)
        {
            _query = query;
        }
        public async Task<Plateau> Handle(GetPlateauByIdQuery request, CancellationToken cancellationToken)
        {
            return await _query.SingleOrDefaultAsync(p => p.Id == request.PlateauId, cancellationToken);
        }
    }
}
using System.Collections.Generic;
using MarsRover.Domain.AggregatesModel.PlateauAggregate;
using MediatR;

namespace MarsRover.Application.Queries
{
    public class GetAllPlateausQuery : IRequest<List<Plateau>>
    {
    }
}
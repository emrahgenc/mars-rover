using System;
using MarsRover.Domain.AggregatesModel.PlateauAggregate;
using MediatR;

namespace MarsRover.Application.Queries
{
    public class GetPlateauByIdQuery: IRequest<Plateau>
    {
        public Guid PlateauId { get; set; }
    }
}
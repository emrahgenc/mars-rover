using System;
using MarsRover.Domain.AggregatesModel.RoverAggregate;
using MediatR;

namespace MarsRover.Application.Queries
{
    public class GetRoverPositionByIdQuery : IRequest<Position>
    {
        public Guid Id { get; protected set; }

        public GetRoverPositionByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
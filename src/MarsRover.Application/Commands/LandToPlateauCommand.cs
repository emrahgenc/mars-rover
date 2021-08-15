using MarsRover.Domain.AggregatesModel.PlateauAggregate;
using MediatR;
using System;

namespace MarsRover.Application.Commands
{
    public class LandToPlateauCommand : IRequest
    {
        public Guid RoverId { get; protected set; }
        public Coordinate Coordinate { get; protected set; }
        public Direction Direction { get; protected set; }
        public Guid PlateauId { get; protected set; }

        public LandToPlateauCommand(Guid roverId, Guid plateauId, Coordinate coordinate, Direction direction)
        {
            RoverId = roverId;
            Coordinate = coordinate;
            Direction = direction;
            PlateauId = plateauId;
        }
    }
}

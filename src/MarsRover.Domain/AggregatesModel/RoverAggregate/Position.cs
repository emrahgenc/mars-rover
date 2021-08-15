using MarsRover.Core.Abstraction.Domain.SeedWork;
using MarsRover.Domain.AggregatesModel.PlateauAggregate;
using System.Collections.Generic;

namespace MarsRover.Domain.AggregatesModel.RoverAggregate
{
    public class Position : ValueObject
    {
        public Coordinate Coordinate { get; protected set; }
        public Direction Direction { get; protected set; }

        protected Position()
        {

        }
        public Position(Coordinate coordinate, Direction direction)
        {
            Coordinate = coordinate;
            Direction = direction;
        }

        public void ChangeCoordinate(int x, int y)
        {
            Coordinate.Change(x, y);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Coordinate.X;
            yield return Coordinate.Y;
            yield return Direction;
        }

        public void ShiftLeft()
        {
            Direction = Direction == Direction.North ? Direction.East : Direction - 1;
        }

        public void ShiftRight()
        {
            Direction = Direction == Direction.East ? Direction.North : Direction + 1;
        }
    }
}
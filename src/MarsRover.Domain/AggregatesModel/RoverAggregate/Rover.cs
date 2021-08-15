using MarsRover.Core.Abstraction;
using MarsRover.Core.Abstraction.Domain.SeedWork;
using MarsRover.Domain.AggregatesModel.PlateauAggregate;
using System;

namespace MarsRover.Domain.AggregatesModel.RoverAggregate
{
    public class Rover : Entity<Guid>, IAggregateRoot
    {
        public string Code { get; protected set; }
        public Position Position { get; protected set; }

        public Guid PlateauId { get; protected set; }

        public Rover(string code)
        {
            Code = code;
        }

        public void LandToPlateau(Guid plateauId, Position position)
        {
            PlateauId = plateauId;
            Position = position;
        }

        public void Forward()
        {
            switch (Position.Direction)
            {
                case Direction.North:
                    Position.ChangeCoordinate(Position.Coordinate.X, Position.Coordinate.Y + 1);
                    break;
                case Direction.West:
                    Position.ChangeCoordinate(Position.Coordinate.X - 1, Position.Coordinate.Y);
                    break;
                case Direction.South:
                    Position.ChangeCoordinate(Position.Coordinate.X, Position.Coordinate.Y - 1);
                    break;
                case Direction.East:
                    Position.ChangeCoordinate(Position.Coordinate.X + 1, Position.Coordinate.Y);
                    break;
                default:
                    ApplicationContext.ThrowBusinessException("Invalid direction");
                    break;
            }
        }

        public void TurnLeft()
        {
            Position.ShiftLeft();
        }

        public void TurnRight()
        {
            Position.ShiftRight();
        }
    }
}

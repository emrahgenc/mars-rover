using MarsRover.Core.Abstraction.Domain.SeedWork;
using System;

namespace MarsRover.Domain.AggregatesModel.PlateauAggregate
{
    public class Plateau : Entity<Guid>, IAggregateRoot
    {
        public string Code { get; protected set; }
        public Size Size { get; protected set; }

        protected Plateau()
        {

        }

        public Plateau(string code, Size size) : this()
        {
            Code = code;
            Size = size;
        }

        public bool IsValid(Coordinate coordinate)
        {
            var isValidX = coordinate.X >= 0 && coordinate.X <= Size.Width;
            var isValidY = coordinate.Y >= 0 && coordinate.Y <= Size.Height;

            return isValidX && isValidY;
        }
    }
}

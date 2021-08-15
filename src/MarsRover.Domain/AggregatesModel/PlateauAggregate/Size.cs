using MarsRover.Core.Abstraction.Domain.SeedWork;
using System.Collections.Generic;

namespace MarsRover.Domain.AggregatesModel.PlateauAggregate
{
    public class Size : ValueObject
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        protected Size()
        {
            
        }
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Width;
            yield return Height;
        }
    }
}
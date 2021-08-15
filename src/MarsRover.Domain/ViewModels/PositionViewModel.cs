using MarsRover.Domain.AggregatesModel.PlateauAggregate;

namespace MarsRover.Domain.ViewModels
{
    public class PositionViewModel
    {
        public Direction Direction { get; protected set; }
        public Coordinate Coordinate { get; protected set; }
    }
}

namespace MarsRover.Domain.AggregatesModel.PlateauAggregate
{
    public class Coordinate
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        protected Coordinate()
        {

        }
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Change(int x, in int y)
        {
            X = x;
            Y = y;
        }
    }
}
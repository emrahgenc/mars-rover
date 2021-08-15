using System;

namespace MarsRoger.Client.ApiClients
{
    public class LandToPlateauRequest
    {
        public Guid RoverId { get; set; }
        public Coordinate Coordinate { get; set; }
        public Direction Direction { get; set; }
        public Guid PlateauId { get; set; }

    }
}
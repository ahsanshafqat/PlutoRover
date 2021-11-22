using System;

namespace PlutoRover.Api
{
    public partial class Rover
    {
        public class RoverInfo
        {
            public Point RoverPosition { get; internal set; }
            public string RoverDirection { get; internal set; }
            public bool RoverHasBeenBlockedByObstacle { get; internal set; }

        }
    }
}

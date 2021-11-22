using System;

namespace PlutoRover.Api
{
    public class MoveRoverResponse
    {

        public Point RoverPosition { get; internal set; }
        public bool RoverHasBeenBlockedByObstacle { get; internal set; }

    }
}

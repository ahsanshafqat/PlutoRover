using System;

namespace PlutoRover.Api
{
    public class Obstacle
    {

        public Obstacle(Point position)
        {
            Position = position;
        }

        public Point Position { get; set; }

    }
}
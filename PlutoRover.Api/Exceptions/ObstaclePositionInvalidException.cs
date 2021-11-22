using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoRover.Api.Exceptions
{
    
    public class ObstaclePositionInvalidException : Exception
    {
        public ObstaclePositionInvalidException()
        {
        }

        public ObstaclePositionInvalidException(string message)
            : base(message)
        {
        }

        public ObstaclePositionInvalidException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

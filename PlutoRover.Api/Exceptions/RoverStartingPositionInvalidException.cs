using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoRover.Api.Exceptions
{
    
    public class RoverStartingPositionInvalidException : Exception
    {
        public RoverStartingPositionInvalidException()
        {
        }

        public RoverStartingPositionInvalidException(string message)
            : base(message)
        {
        }

        public RoverStartingPositionInvalidException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

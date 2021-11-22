using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoRover.Api.Exceptions
{

    public class RoverStartingDirectionInvalidException : Exception
    {
        public RoverStartingDirectionInvalidException()
        {
        }

        public RoverStartingDirectionInvalidException(string message)
            : base(message)
        {
        }

        public RoverStartingDirectionInvalidException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoRover.Api.Exceptions
{
    
    public class GridDimensionInvalidException : Exception
    {
        public GridDimensionInvalidException()
        {
        }

        public GridDimensionInvalidException(string message)
            : base(message)
        {
        }

        public GridDimensionInvalidException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

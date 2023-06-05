using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Domain.Exceptions
{
    public class GamesOnCourtException : Exception
    {
        public GamesOnCourtException(string message = "Cannot delete court with games!") : base(message)
        {
        }
    }
}

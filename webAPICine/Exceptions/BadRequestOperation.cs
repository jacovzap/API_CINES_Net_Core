using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPICine.Exceptions
{
    public class BadRequestOperation : Exception
    {
        public BadRequestOperation(string message)
          : base(message)
        {
        }
    }
}

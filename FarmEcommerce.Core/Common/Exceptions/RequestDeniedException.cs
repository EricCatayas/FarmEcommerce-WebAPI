using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace FarmEcommerce.Core.Common.Exceptions
{
    public class RequestDeniedException : Exception
    {
        public RequestDeniedException() : base("Request Denied.")
        {
        }
        public RequestDeniedException(string message) : base(message)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace FarmEcommerce.Core.Common.Exceptions
{
    public class UnathorizedRequestException : Exception
    {
        public UnathorizedRequestException() : base("Request is unauthorized.")
        {
        }
        public UnathorizedRequestException(string message) : base(message)
        {
        }
    }
}


namespace FarmEcommerce.Core.Common.Exceptions
{
    public class RegistrationException : Exception
    {
        public RegistrationException() : base("Registration failed") { }
        public RegistrationException(string message) : base(message) { }
    }
}

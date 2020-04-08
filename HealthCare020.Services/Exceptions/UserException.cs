using System;

namespace HealthCare020.Services.Exceptions
{
    public class UserException : Exception
    {
        public UserException(string message) : base(message)
        {
        }
    }
}
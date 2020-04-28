using System;

namespace HealthCare020.Services.Exceptions
{
    public class ForbiddenException:Exception
    {
        public ForbiddenException(string message):base(message)
        {
            
        }
    }
}
namespace HealthCare020.Services.Exceptions
{
    public class NotFoundException:UserException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
namespace HealthCare020.Core.ServiceModels
{
    public class ValidationProblemDetails
    {
        public string Type { get; set; }
        public int? Status { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }
    }
}
namespace HealthCare020.Core.ResourceParameters
{
    public class BaseResourceParameters
    {
        private const int MaxPageSize = 20;

        public int PageNumber { get; set; } = 1;

        private int _pageSize = 6;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public string OrderBy { get; set; }
        //public string Fields { get; set; }
    }
}
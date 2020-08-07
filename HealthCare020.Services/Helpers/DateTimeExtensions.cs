using System;

namespace HealthCare020.Services.Helpers
{
    public static class DateTimeExtensions
    {
        public static double SecondsDifference(this DateTime dateTime, DateTime dateTimeToCompare)
        {
            return (dateTimeToCompare-dateTime).TotalSeconds;
        }
    }
}
namespace COMPANY.Common.Helpers
{
    using System;

    public static class DateHelper
    {
        public static DateTime UnixTimeStampToDateTime(this long timestamp)
        {
            DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return date.AddSeconds(timestamp);
        }
    }

}

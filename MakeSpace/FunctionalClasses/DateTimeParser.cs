using System;

namespace MakeSpace.FunctionalClasses
{
    public static class DateTimeParser
    {
        public static bool TryParse(string dateTimeStr, out DateTime dateTime)
        {
            if (DateTime.TryParse(dateTimeStr, out dateTime))
            {
                if (IsValidTimeInterval(dateTime))
                    return true;
            }

            return false;
        }

        private static bool IsValidTimeInterval(DateTime dateTime)
        {
            int minutes = dateTime.Minute;
            return minutes % (int)TimeConstraints.Interval == 0;
        }
    }
}

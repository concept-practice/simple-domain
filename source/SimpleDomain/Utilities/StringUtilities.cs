namespace SimpleDomain.Utilities
{
    using System;
    using System.Globalization;

    public static class StringUtilities
    {
        public static TimeSpan ParseToTimeSpan(this string value)
        {
            return TimeSpan.Parse(value, CultureInfo.InvariantCulture);
        }

        public static string ToStringInvariant(this double value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}

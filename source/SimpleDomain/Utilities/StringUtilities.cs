using System;
using System.Globalization;

namespace SimpleDomain.Utilities
{
    /// <summary>
    /// Contains numerous extension methods for converting strings.
    /// </summary>
    public static class StringUtilities
    {
        /// <summary>
        /// Converts a string into a TimeSpan with invariant culture.
        /// </summary>
        /// <param name="value">The string to be converted.</param>
        /// <returns>A TimeSpan object.</returns>
        public static TimeSpan ParseToTimeSpan(this string value)
        {
            return TimeSpan.Parse(value, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts a double to a string with invariant culture.
        /// </summary>
        /// <param name="value">The double to be converted.</param>
        /// <returns>A string object.</returns>
        public static string ToStringInvariant(this double value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}

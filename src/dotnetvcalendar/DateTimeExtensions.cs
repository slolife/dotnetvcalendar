using System;

namespace VCalendar
{
    internal static class DateTimeExtensions
    {
        /// <summary>Converts a DateTime value to a UTC string representation</summary>
        /// <param name="value">DateTime value to convert</param>
        /// <returns>A string representation of the specified DateTime value in the form of yyyyMMdd\\THHmmss\\Z</returns>
        public static string UniversalTimeString(this DateTime value)
        {
            return value.ToUniversalTime().ToString("yyyyMMdd\\THHmmss\\Z", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}

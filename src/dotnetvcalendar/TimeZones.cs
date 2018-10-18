using System.Collections.ObjectModel;
using System.Text;

namespace VCalendar
{
   /// <summary>A collection of CalendarTimeZone objects</summary>
    public class TimeZoneCollection : Collection<CalendarTimeZone>
    {
        /// <summary>Returns a string that represents the collection of TimeZone objects</summary>
        /// <returns>A string that represents the collection of TimeZone objects</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (CalendarTimeZone item in this)
            {
                result.Append(item);
            }

            return result.ToString();
        }
    }
}

// $Date:  $
// $Revision:  $

using System.Text;

namespace VCalendar
{
    /// <summary>A Timezone object for vCalendar</summary>
    public class CalendarTimeZone
    {
        /// <summary>Initializes a new instance of the <see cref="CalendarTimeZone"/> class.</summary>
        public CalendarTimeZone()
        {
            StandardSection = new StandardTimeZoneSection();
            DaylightSection = new DaylightTimeZoneSection();
        }

        /// <summary>Gets or sets the identifier for this timezone.</summary>
        public string TimeZoneId { get; set; }

        /// <summary>Gets or sets the standard timezone section information.</summary>
        public StandardTimeZoneSection StandardSection { get; set; }

        /// <summary>Gets or sets the daylight timezone section.</summary>
        public DaylightTimeZoneSection DaylightSection { get; set; }

        /// <summary>Converts this object to a valid vCalendar timezone string segment</summary>
        /// <returns>A valid vCalendar timezone string segment</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("BEGIN:VTIMEZONE");
            result.AppendFormat("TZID:{0}{1}", TimeZoneId, System.Environment.NewLine);
            result.Append(this.StandardSection);
            result.Append(this.DaylightSection);
            result.AppendLine("END:VTIMEZONE");
            return result.ToString();
        }
    }
}

// $Date:  $
// $Revision:  $

namespace VCalendar
{
    /// <summary>Represents daylight savings time in a timezone</summary>
    public class DaylightTimeZoneSection : TimeZoneSection
    {
        /// <summary>Gets the section name of this timezone.</summary>
        protected override string SectionName
        {
            get { return "DAYLIGHT"; }
        }
    }
}

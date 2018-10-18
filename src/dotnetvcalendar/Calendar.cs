using System;
using System.Text;

namespace VCalendar
{
    /// <summary>Contains all information about a event</summary>
    /// <remarks>
    ///     Specs can be found at: https://www.ietf.org/rfc/rfc2445.txt
    /// </remarks>
    public class Calendar
    {
        private string m_Name = string.Empty;

        /// <summary>Initializes a new instance of the <see cref="Calendar"/> class.</summary>
        public Calendar()
        {

        }

        /// <summary>Initializes a new instance of the <see cref="Calendar"/> class.</summary>
        /// <param name="value">A EventInformation object to initialize the vCalendar object with.</param>
        public Calendar(EventInformation value)
        {
            Events.Add(value);
        }

        /// <summary>Gets or sets the name of the calendar.</summary>
        /// <remarks>Will populate the X-WR-CALNAME field.</remarks>
        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value ?? string.Empty;
            }
        }

        /// <summary>Gets the calendar's <see cref="EventCollection"/>.</summary>
        public EventCollection Events => new EventCollection();

        /// <summary>Gets a collection of timezone objects used by the calendar's events.</summary>
        public TimeZoneCollection TimeZones => new TimeZoneCollection();

        /// <summary>Converts the vCalendar object data to a string representation</summary>
        /// <returns>A string representation of the vCalendar object</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("BEGIN:VCALENDAR");

            // The following two lines seem to be required by Outlook to get the alarm settings
            result.AppendLine("VERSION:2.0");
            result.AppendLine("METHOD:PUBLISH");
            if (!string.IsNullOrEmpty(m_Name) && this.Events.Count == 1)
            {
                result.AppendFormat("NAME:{0}{1}", m_Name, System.Environment.NewLine);
                result.AppendFormat("X-WR-CALNAME:{0}{1}", m_Name, System.Environment.NewLine);
            }
            else
            {
                throw new InvalidOperationException("Calendar.Name should not be set for single event/meeting calendars.")
            }

            result.Append(this.TimeZones);
            result.Append(this.Events);

            result.AppendLine("END:VCALENDAR");
            return result.ToString();
        }
    }
}
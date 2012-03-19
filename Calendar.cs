// $Date:  $
// $Revision:  $

using System.Text;

namespace VCalendar
{
    /// <summary>Contains all information about a event</summary>
    /// <remarks>
    ///     Specs can be found at: http://www.imc.org/pdi/pdiproddev.html
    /// </remarks>
    public class Calendar
    {
        private readonly EventCollection m_Events = new EventCollection();
        private readonly TimeZoneCollection m_TimeZones = new TimeZoneCollection();
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
        public EventCollection Events
        {
            get
            {
                return m_Events;
            }
        }

        /// <summary>Gets a collection of timezone objects used by the calendar's events.</summary>
        public TimeZoneCollection TimeZones
        {
            get
            {
                return m_TimeZones;
            }
        }

        /// <summary>Converts the vCalendar object data to a string representation</summary>
        /// <returns>A string representation of the vCalendar object</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("BEGIN:VCALENDAR");

            // The following two lines seem to be required by Outlook to get the alarm settings
            result.AppendLine("VERSION:2.0");
            result.AppendLine("METHOD:PUBLISH");
            if (!string.IsNullOrEmpty(m_Name))
            {
                result.AppendFormat("X-WR-CALNAME:{0}{1}", m_Name, System.Environment.NewLine);
            }

            result.Append(TimeZones.ToString());
            result.Append(Events.ToString());

            result.AppendLine("END:VCALENDAR");
            return result.ToString();
        }
    }
}
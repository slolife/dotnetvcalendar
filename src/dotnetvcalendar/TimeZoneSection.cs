using System;
using System.Text;

namespace VCalendar
{
    /// <summary>Abstract class representing a Timezone section</summary>
    public abstract class TimeZoneSection
    {
        private string m_Name;
        private TimeSpan m_TimeZoneOffset;
        private TimeSpan m_PreviousTimeZoneOffset;
        private DateTime m_StartDate;
        private Recurrence m_Rule;

        /// <summary>Gets or sets the name of the TimeZone section.</summary>
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        /// <summary>Gets or sets offset from GMT when in this TimeZone section.</summary>
        public TimeSpan TimeZoneOffset
        {
            get { return m_TimeZoneOffset; }
            set { m_TimeZoneOffset = value; }
        }

        /// <summary>Gets or sets offset from GMT of the next TimeZone section.</summary>
        public TimeSpan PreviousTimeZoneOffset
        {
            get { return m_PreviousTimeZoneOffset; }
            set { m_PreviousTimeZoneOffset = value; }
        }

        /// <summary>Gets or sets the date when this TimeZone section starts.</summary>
        public DateTime StartDate
        {
            get { return m_StartDate; }
            set { m_StartDate = value; }
        }

        /// <summary>Gets or sets the recurrence rule for when the TimeZone shifts again.</summary>
        public Recurrence Rule
        {
            get { return m_Rule; }
            set { m_Rule = value; }
        }

        /// <summary>Gets the section name of this section.</summary>
        /// <remarks>Either STANDARD OR DAYLIGHT</remarks>
        protected abstract string SectionName
        {
            get;
        }

        /// <summary>Converts this object to a valid vCalendar timezone section string segment</summary>
        /// <returns>A valid vCalendar timezone section string segment</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("BEGIN:{0}{1}", SectionName, Environment.NewLine);
            result.AppendFormat("TZOFFSETTO:{0:00;-00}{1:00}{2}", m_TimeZoneOffset.Hours, m_TimeZoneOffset.Minutes, Environment.NewLine);
            result.AppendFormat("TZOFFSETFROM:{0:00;-00}{1:00}{2}", m_PreviousTimeZoneOffset.Hours, m_PreviousTimeZoneOffset.Minutes, Environment.NewLine);
            result.AppendFormat("TZNAME:{0}{1}", m_Name, Environment.NewLine);
            result.AppendFormat("DTSTART:{0}{1}", m_StartDate.UniversalTimeString(), Environment.NewLine);
            if (m_Rule != null)
            {
                result.Append(this.m_Rule);
            }
            result.AppendFormat("END:{0}{1}", SectionName, Environment.NewLine);
            return result.ToString();
        }
    }
}

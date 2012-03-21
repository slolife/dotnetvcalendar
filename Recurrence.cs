// $Date:  $
// $Revision:  $

using System;
using System.Text;

namespace VCalendar
{
    /// <summary>A Recurrence object for the vCalendar class</summary>
    /// <remarks>
    ///     RRULE:FREQ=YEARLY;  INTERVAL=1; BYMONTHDAY=12; BYMONTH=11; WKST=SU          //Every year on Nov 12
    ///     RRULE:FREQ=YEARLY;  INTERVAL=1; BYDAY=TU; BYMONTH=11; BYSETPOS=2;WKST=SU    //Every 2nd Tue of Nov, yearly
    ///     RRULE:FREQ=YEARLY;  INTERVAL=1; BYDAY=SA; BYMONTH=11; BYSETPOS=-1;WKST=SU   //Last Sat of Nov
    ///     RRULE:FREQ=YEARLY;  INTERVAL=1; BYDAY=SA;BYMONTH=11; BYSETPOS=1;WKST=SU     //First Sat of Nov, yearly
    ///     RRULE:FREQ=WEEKLY;  INTERVAL=2; BYDAY=SU,MO,TU,WE,TH,FR,SA;WKST=SU          //Every 2 weeks on all days
    ///     RRULE:FREQ=DAILY;   INTERVAL=1; UNTIL=20031110T000000Z;WKST=SU              //Daily every 1 day until end date
    ///     RRULE:FREQ=DAILY;   INTERVAL=1; COUNT=10;BYDAY=MO,TU,WE,TH,FR;WKST=SU       //Daily every day for 10 occurrences
    /// </remarks>
    public class Recurrence
    {
        private int m_Month;
        private int m_MonthDay;

        /// <summary>Gets or sets the frequency of the event recurrence.</summary>
        public Frequency Frequency { get; set; }

        /// <summary>First day of the week</summary>
        public DayOfWeek WeekStart = DayOfWeek.Sunday;

        /// <summary>Gets or sets the days of the week that the event occurs on.</summary>
        public DaysOfWeek Weekdays { get; set; }

        /// <summary>Gets or sets the interval of the frequency.</summary>
        public int Interval { get; set; }

        /// <summary>Gets or sets the when the recurring event will stop.</summary>
        public DateTime EndDateTime { get; set; }

        /// <summary>Gets or sets the number of occurrences of this event.</summary>
        public int Occurences { get; set; }

        /// <summary>Gets or sets the day of the month.</summary>
        public int MonthDay
        {
            get
            {
                return m_MonthDay;
            }

            set
            {
                if (value >= 1 || value <= 31)
                {
                    m_MonthDay = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value", value, "Must be between 1 and 31.");
                }
            }
        }

        /// <summary>Gets or sets the month of the year.</summary>
        public int Month
        {
            get
            {
                return m_Month;
            }

            set
            {
                if (value > 0 && value < 13)
                {
                    m_Month = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value", value, "Must be between 1 and 12.");
                }
            }
        }

        /// <summary>Converts this Recurrence object to a valid vCalendar recurrence string segment</summary>
        /// <returns>A valid vCalendar recurrence string segment</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("RRULE:");
            result.AppendFormat("FREQ={0};", Frequency.ToString().ToUpper());
            if (Interval > 0)
            {
                result.AppendFormat("INTERVAL={0};", Interval);
            }

            if (Month > 0)
            {
                result.AppendFormat("BYMONTH={0};", Month);
            }

            if (EndDateTime > DateTime.MinValue)
            {
                result.AppendFormat("UNTIL={0};", EndDateTime.UniversalTimeString());
            }

            if (Occurences > 0)
            {
                result.AppendFormat("COUNT={0};", Occurences);
            }

            if (Weekdays > 0)
            {
                result.AppendFormat("BYDAY={0};", ConvertWeekDaysCommaDelimited());
            }

            switch (Frequency)
            {
                case Frequency.Daily:
                    break;
                case Frequency.Weekly:
                    break;
                case Frequency.Monthly:
                    break;
                case Frequency.Quarterly:
                    break;
                case Frequency.Yearly:
                    break;
                default:
                    break;
            }

            result.AppendFormat("WKST={0}", WeekStart.ToString().Substring(0, 2).ToUpper());
            result.AppendLine();
            return result.ToString();
        }

        private string ConvertWeekDaysCommaDelimited()
        {
            StringBuilder result = new StringBuilder();
            if (Convert.ToBoolean(Weekdays & DaysOfWeek.Sunday))
            {
                result.Append("SU");
            }

            if (Convert.ToBoolean(Weekdays & DaysOfWeek.Monday))
            {
                if (result.Length > 0)
                {
                    result.Append(",");
                }

                result.Append("MO");
            }

            if (Convert.ToBoolean(Weekdays & DaysOfWeek.Tuesday))
            {
                if (result.Length > 0)
                {
                    result.Append(",");
                }

                result.Append("TU");
            }

            if (Convert.ToBoolean(Weekdays & DaysOfWeek.Wednesday))
            {
                if (result.Length > 0)
                {
                    result.Append(",");
                }

                result.Append("WE");
            }

            if (Convert.ToBoolean(Weekdays & DaysOfWeek.Thursday))
            {
                if (result.Length > 0)
                {
                    result.Append(",");
                }

                result.Append("TH");
            }

            if (Convert.ToBoolean(Weekdays & DaysOfWeek.Friday))
            {
                if (result.Length > 0)
                {
                    result.Append(",");
                }

                result.Append("FR");
            }

            if (Convert.ToBoolean(Weekdays & DaysOfWeek.Saturday))
            {
                if (result.Length > 0)
                {
                    result.Append(",");
                }

                result.Append("SA");
            }

            return result.ToString();
        }
    }
}

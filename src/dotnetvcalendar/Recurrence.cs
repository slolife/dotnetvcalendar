using System;
using System.Collections.Generic;
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
        private const int MaxDayValue = 31;
        private const int MinDayValue = 1;
        private const int MaxMonthValue = 12;
        private const int MinMonthValue = 1;

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
        public int Occurrences { get; set; }

        /// <summary>Gets or sets the day of the month.</summary>
        public int MonthDay
        {
            get
            {
                return m_MonthDay;
            }
            set
            {
                if (value >= MinDayValue || value <= MaxDayValue)
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
                if (value >= MinMonthValue && value <= MaxMonthValue)
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

            if (Occurrences > 0)
            {
                result.AppendFormat("COUNT={0};", Occurrences);
            }

            if (Weekdays > 0)
            {
                result.AppendFormat("BYDAY={0};", ConvertWeekDaysToCommaDelimited());
            }

            result.AppendFormat("WKST={0}", WeekStart.ToString().Substring(0, 2).ToUpper());
            result.AppendLine();
            return result.ToString();
        }

        private string ConvertWeekDaysToCommaDelimited()
        {
            var list = new List<string>();
            if (Convert.ToBoolean(Weekdays & DaysOfWeek.Sunday))
            {
                list.Add("SU");
            }

            if (Convert.ToBoolean(Weekdays & DaysOfWeek.Monday))
            {
                list.Add("MO");
            }

            if (Convert.ToBoolean(Weekdays & DaysOfWeek.Tuesday))
            {
                list.Add("TU");
            }

            if (Convert.ToBoolean(Weekdays & DaysOfWeek.Wednesday))
            {
                list.Add("WE");
            }

            if (Convert.ToBoolean(Weekdays & DaysOfWeek.Thursday))
            {
                list.Add("TH");
            }

            if (Convert.ToBoolean(Weekdays & DaysOfWeek.Friday))
            {
                list.Add("FR");
            }

            if (Convert.ToBoolean(Weekdays & DaysOfWeek.Saturday))
            {
                list.Add("SA");
            }

            var result = string.Join(",", list.ToArray());
            return result;
        }
    }
}

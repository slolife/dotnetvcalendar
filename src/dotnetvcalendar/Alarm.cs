using System;
using System.Text;

namespace VCalendar
{
    /// <summary>An alarm object for the vCalendar class</summary>
    public class Alarm : EncodedData
    {
        private const string DefaultAction = "DISPLAY";
        private const string DefaultDescription = "Reminder";
        private readonly TimeSpan DefaultTrigger = TimeSpan.FromDays(1);

        /// <summary>Initializes a new instance of the <see cref="Alarm"/> class.</summary>
        public Alarm()
        {
            Trigger = DefaultTrigger;
            Action = DefaultAction;
            Description = DefaultDescription;
        }

        /// <summary>Gets or sets the amount of time before event to display alarm.</summary>
        public TimeSpan Trigger { get; set; }

        /// <summary>Gets or sets the action to take to notify user of alarm.</summary>
        public string Action { get; set; }

        /// <summary>Gets or sets the description of the alarm.</summary>
        public string Description { get; set; }

        /// <summary>Converts this vAlarm object to a valid vCalendar alarm string segment</summary>
        /// <returns>A valid vCalendar alarm string segment</returns>
        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine("BEGIN:VALARM");
            result.AppendFormat("TRIGGER:P{0}DT{1}H{2}M", Trigger.Days, Trigger.Hours, Trigger.Minutes).AppendLine();
            result.AppendFormat("ACTION:{0}", Action).AppendLine();
            result.AppendFormat("DESCRIPTION:{0}", FormatNewlines(Description)).AppendLine();
            result.AppendFormat("END:VALARM").AppendLine();
            return result.ToString();
        }
    }
}
// $Date:  $
// $Revision:  $

using System;
using System.Text;

namespace VCalendar
{
    /// <summary>An alarm object for the vCalendar class</summary>
    public class Alarm
    {
        /// <summary>Initializes a new instance of the <see cref="Alarm"/> class.</summary>
        public Alarm()
        {
            Trigger = TimeSpan.FromDays(1);
            Action = "DISPLAY";
            Description = "Reminder";
        }

        /// <summary>Initializes a new instance of the <see cref="Alarm"/> class.</summary>
        /// <param name="setTrigger">Amount of time before event to trigger alarm</param>
        public Alarm(TimeSpan setTrigger)
        {
            Trigger = setTrigger;
            Action = "DISPLAY";
            Description = "Reminder";
        }

        /// <summary>Initializes a new instance of the <see cref="Alarm"/> class.</summary>
        /// <param name="setTrigger">Amount of time before event to trigger alarm</param>
        /// <param name="setAction">Action of the alarm</param>
        /// <param name="setDescription">Description of the alarm</param>
        public Alarm(TimeSpan setTrigger, string setAction, string setDescription)
        {
            Trigger = setTrigger;
            Action = setAction;
            Description = setDescription;
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
            result.AppendFormat("DESCRIPTION:{0}", Description).AppendLine();
            result.AppendFormat("END:VALARM").AppendLine();
            return result.ToString();
        }
    }
}
using System.Collections.ObjectModel;
using System.Text;

namespace VCalendar
{
    /// <summary>A collection of vAlarms objects</summary>
    public class AlarmCollection : Collection<Alarm>
    {
        /// <summary>Returns a string that represents the current vAlarm object</summary>
        /// <returns>A string that represents the current vAlarm object</returns>
        public override string ToString()
        {
            var result = new StringBuilder();
            foreach (Alarm item in this)
            {
                result.Append(item);
            }

            return result.ToString();
        }
    }
}

// $Date:  $
// $Revision:  $

using System.Collections.ObjectModel;
using System.Text;

namespace VCalendar
{
    /// <summary>A collection of EventInformation objects</summary>
    public class EventCollection : Collection<EventInformation>
    {
        /// <summary>Returns a string that represents the collection of EventInformation objects</summary>
        /// <returns>A string that represents the collection of EventInformation objects</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (EventInformation item in this)
            {
                result.Append(item);
            }

            return result.ToString();
        }
    }
}

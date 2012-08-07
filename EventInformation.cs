// $Date:  $
// $Revision:  $

using System;
using System.Collections.Specialized;
using System.Text;

namespace VCalendar
{
    /// <summary>An event object for the vCalendar class</summary>
    public class EventInformation
    {
        /// <summary>Separator character used in the output of the Categories collection.</summary>
        public const string CategorySeparator = ";";

        private readonly StringCollection m_Categories;
        private readonly AlarmCollection m_Alarms;

        /// <summary>Initializes a new instance of the <see cref="EventInformation"/> class.</summary>
        public EventInformation()
        {
            m_Categories = new StringCollection();
            m_Alarms = new AlarmCollection();
        }

        /// <summary>Gets or sets the unique identifier for the event.</summary>
        public string UID { get; set; }

        /// <summary>Gets or sets the start date of event. Will be automatically converted to GMT.</summary>
        public DateTime DTStart { get; set; }

        /// <summary>Gets or sets the end date of event. Will be automatically converted to GMT.</summary>
        public DateTime DTEnd { get; set; }

        /// <summary>Gets or sets the timestamp. Will be automatically converted to GMT.</summary>
        public DateTime DTStamp { get; set; }

        /// <summary>Gets or sets the summary of the event.</summary>
        public string Summary { get; set; }

        /// <summary>Gets or sets the event organizer.</summary>
        /// <remarks>Can be a mailto:, url, or just a name.</remarks>
        public string Organizer { get; set; }

        /// <summary>Gets or sets the location of the event.</summary>
        /// <remarks>At least for Outlook, recommend that there not be any line breaks in the text.</remarks>
        public string Location { get; set; }

        /// <summary>Gets or sets the description of event.</summary>
        public string Description { get; set; }

        /// <summary>Gets or sets the URL for the event.</summary>
        public string Url { get; set; }
        
        /// <summary>Gets the <see cref="AlarmCollection"/> for this event.</summary>
        public AlarmCollection Alarms
        {
            get
            {
                return m_Alarms;
            }
        }

        /// <summary>Gets or sets the recurrence of the event.</summary>
        public Recurrence Recurrence { get; set; }

        /// <summary>Gets or sets a value indicating whether the event is private or public.</summary>
        public bool IsPrivate { get; set; }
        
        /// <summary>Gets or sets the status of the event.</summary>
        public EventStatus Status { get; set; }

        /// <summary>Gets or sets the priority of the event.</summary>
        /// <remarks>
        ///     1 indicates the highest priority.
        ///     Outlook uses 1 as high priority, 5 as normal priority, and 9 as high priority
        /// </remarks>
        public int Priority { get; set; }

        /// <summary>Gets or sets the sequence number, which corresponds to the number of revisions this event has had.</summary>
        public int Sequence { get; set; }

        /// <summary>Gets or sets the whether the event is transparent to free time searches.</summary>
        /// <remarks>
        /// The standards state that a value of 0 is busy, 1 is free and greater than 1 is to be determined by the applicaton
        /// Outlook does not conform to the standards and uses OPAQUE for busy, TRANSPARENT for free
        /// </remarks>
        public string TimeTransparency { get; set; }

        /// <summary>Gets the category collection for this event.</summary>
        public StringCollection Categories
        {
            get
            {
                return m_Categories;
            }
        }

        /// <summary>Converts this EventInformation object to a valid vCalendar event string segment</summary>
        /// <returns>A valid vCalendar event string segment</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("BEGIN:VEVENT{0}", Environment.NewLine);
            result.AppendFormat("UID:{0}{1}", UID, Environment.NewLine);
            result.AppendFormat("SUMMARY:{0}{1}", Summary, Environment.NewLine);
            result.AppendFormat("ORGANIZER:{0}{1}", Organizer, Environment.NewLine);
            result.AppendFormat("DTSTART:{0}{1}", DTStart.UniversalTimeString(), Environment.NewLine);
            result.AppendFormat("DTEND:{0}{1}", DTEnd.UniversalTimeString(), Environment.NewLine);
            if (!String.IsNullOrEmpty(Location))
            {
                result.AppendFormat("LOCATION:{0}{1}", Location, Environment.NewLine);
            }

            if (!String.IsNullOrEmpty(TimeTransparency))
            {
                result.AppendFormat("TRANSP:{0}{1}", TimeTransparency, Environment.NewLine);
            }

            if (Recurrence != null)
            {
                result.Append(this.Recurrence);
            }

            result.AppendFormat("DTSTAMP:{0}{1}", DateTime.UtcNow.UniversalTimeString(), Environment.NewLine);

            var descriptionEncoding = string.Empty;
            if (Description.Contains(Environment.NewLine))
            {
                descriptionEncoding = ";ENCODING=QUOTED-PRINTABLE";
            }
            result.AppendFormat("DESCRIPTION{0}:{1}{2}", descriptionEncoding, Description.Replace(Environment.NewLine, "=0D=0A=" + Environment.NewLine), Environment.NewLine);
            
            if (!string.IsNullOrEmpty(Url))
            {
                result.AppendFormat("URL:{0}{1}", Url, Environment.NewLine);
            }

            result.Append(this.Alarms);

            result.AppendFormat("CLASS:{0}{1}", IsPrivate ? "PRIVATE" : "PUBLIC", Environment.NewLine);

            if (Priority > 0)
            {
                result.AppendFormat("PRIORITY:{0}{1}", Priority, Environment.NewLine);
            }

            result.AppendFormat("STATUS:{0}{1}", Status.ToString().ToUpper(), Environment.NewLine);
            result.AppendFormat("SEQUENCE:{0}{1}", Sequence, Environment.NewLine);

            if (Categories.Count > 0)
            {
                result.Append("CATEGORIES:");
                bool itemAdded = false;
                foreach (string category in Categories)
                {
                    if (category.IndexOf(CategorySeparator) > -1)
                    {
                        throw new FormatException("Category name cannot contain (" + CategorySeparator + ") characters since they are used as delimiters");
                    }
                    
                    if (itemAdded)
                    {
                        result.Append(CategorySeparator);
                    }

                    result.Append(category);
                    itemAdded = true;
                }

                result.Append(Environment.NewLine);
            }

            result.AppendFormat("END:VEVENT{0}", Environment.NewLine);
            return result.ToString();
        }
    }
}
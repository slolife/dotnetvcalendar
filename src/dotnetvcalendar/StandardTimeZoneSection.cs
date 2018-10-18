namespace VCalendar
{
    /// <summary>A standard timezone section</summary>
    public class StandardTimeZoneSection : TimeZoneSection
    {
        /// <summary>Gets the SectionName of this section.</summary>
        /// <remarks>Default is STANDARD.</remarks>
        protected override string SectionName
        {
            get { return "STANDARD"; }
        }
    }
}

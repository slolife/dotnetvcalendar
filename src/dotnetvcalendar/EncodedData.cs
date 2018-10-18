using System.Text;

namespace VCalendar
{
    public abstract class EncodedData
    {
        public string FormatNewlines(string value)
        {
            var result = value.Replace(@"\r\n", @"\\n");
            result = value.Replace(@"\r", @"\\n");
            // TODO: What to do about \n that exists?
            return result;
        }
    }
}

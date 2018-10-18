using Xunit;

namespace tests
{
    public class RecurrenceTests
    {
        [Fact]
        public void Test_Recurrence_ConvertWeekDaysToCommaDelimited_Multiple()
        {
            var recurrence = new VCalendar.Recurrence();
            recurrence.Weekdays = VCalendar.DaysOfWeek.Monday | VCalendar.DaysOfWeek.Wednesday | VCalendar.DaysOfWeek.Friday;
            var result = recurrence.ToString();
            Assert.Contains("BYDAY=MO,WE,FR;", result);
        }

        [Fact]
        public void Test_Recurrence_ConvertWeekDaysToCommaDelimited_None()
        {
            var recurrence = new VCalendar.Recurrence();
            var result = recurrence.ToString();
            Assert.DoesNotContain("BYDAY=", result);
        }

        [Fact]
        public void Test_Recurrence_ConvertWeekDaysToCommaDelimited_Single()
        {
            var recurrence = new VCalendar.Recurrence();
               recurrence.Weekdays = VCalendar.DaysOfWeek.Tuesday;
            var result = recurrence.ToString();
            Assert.Contains("BYDAY=TU;", result);
        }
    }
}

using System.Globalization;

public class WeekHelper
{
    public static (DateTime StartDate, DateTime EndDate) GetWeekStartAndEnd(int year, int weekNumber)
    {
        CultureInfo culture = CultureInfo.CurrentCulture;
        DateTime jan4 = new DateTime(year, 1, 4);

        // Get the first day of the year
        int daysOffset = DayOfWeek.Monday - jan4.DayOfWeek;
        DateTime firstMonday = jan4.AddDays(daysOffset);

        // Get the start of the requested week
        DateTime weekStart = firstMonday.AddDays((weekNumber - 1) * 7);
        DateTime weekEnd = weekStart.AddDays(6).AddHours(23).AddMinutes(59).AddSeconds(59);

        return (weekStart, weekEnd);
    }
}
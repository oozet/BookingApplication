using System;
using Xunit;

public class WeekHelperTests
{
    [Theory]
    [InlineData(2021, 1, "2021-01-04 00:00:00", "2021-01-10 23:59:59")]
    [InlineData(2022, 1, "2022-01-03 00:00:00", "2022-01-09 23:59:59")]
    [InlineData(2023, 52, "2023-12-25 00:00:00", "2023-12-31 23:59:59")]
    [InlineData(2024, 1, "2024-01-01 00:00:00", "2024-01-07 23:59:59")]
    public void GetWeekStartAndEnd_ShouldReturnCorrectDay(int year, int week, string expectedStart, string expectedEnd)
    {
        DateTime expectedStartDate = DateTime.ParseExact(expectedStart, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        DateTime expectedEndDate = DateTime.ParseExact(expectedEnd, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

        var (actualStart, actualEnd) = WeekHelper.GetWeekStartAndEnd(year, week);

        Assert.Equal(expectedStartDate, actualStart);
        Assert.Equal(expectedEndDate, actualEnd);
    }
}

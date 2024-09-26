namespace SharedKernel.Common.Extension;

public static class DateTimeExtension
{
    /// <summary>
    /// This is a trick to hack DateTime to jump to next day and turn back 1 tick to close next day as much as possible
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime End(this DateTime date) => date.AddDays(1).AddTicks(-1);

    /// <summary>
    /// This is a trick to hack DateTimeOffset to jump to next day and turn back 1 tick to close next day as much as possible
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTimeOffset End(this DateTimeOffset date) => date.AddDays(1).AddTicks(-1);
}
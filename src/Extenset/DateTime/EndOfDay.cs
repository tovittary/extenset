namespace Extenset;

/// <summary>
/// Extension methods for <see cref="DateTime" />.
/// </summary>
public static partial class DateTimeExtensions
{
    /// <summary>
    /// Returns a new <see cref="DateTime" /> value corresponding to the end of the day specified
    /// in the <paramref name="dateTime" /> value.
    /// </summary>
    /// <param name="dateTime">The <see cref="DateTime" /> value whose end of day is to be returned.</param>
    /// <returns>A <see cref="DateTime" /> value corresponding to the end of the day.</returns>
    public static DateTime EndOfDay(this DateTime dateTime) => dateTime.Date.AddDays(1).AddTicks(-1);
}

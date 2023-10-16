namespace Extenset;

/// <summary>
/// Extension methods for <see cref="DateTime" />.
/// </summary>
public static partial class DateTimeExtensions
{
    /// <summary>
    /// Converts the <see cref="DateTime" /> to a unix timestamp in milliseconds.
    /// </summary>
    /// <param name="dateTime">The <see cref="DateTime" /> to convert.</param>
    /// <returns>The unix timestamp representation of the <see cref="DateTime" /> in milliseconds.</returns>
    /// <seealso cref="ToUnixTimeSpan" />
    public static long ToUnixMilliseconds(this DateTime dateTime)
    {
        var unixTimeStamp = dateTime.ToUnixTimeSpan();
        return (long)unixTimeStamp.TotalMilliseconds;
    }
}

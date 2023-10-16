namespace Extenset;

/// <summary>
/// Extension methods for <see cref="DateTime" />.
/// </summary>
public static partial class DateTimeExtensions
{
    /// <summary>
    /// Converts the <see cref="DateTime" /> to a unix timestamp in a form of <see cref="TimeSpan" />.
    /// </summary>
    /// <param name="dateTime">The <see cref="DateTime" /> to convert.</param>
    /// <returns>
    /// The unix timestamp representation of the <see cref="DateTime" /> in a form of <see cref="TimeSpan" />.
    /// </returns>
    /// <exception cref="ArgumentException">The year cannot be earlier than 1970.</exception>
    public static TimeSpan ToUnixTimeSpan(this DateTime dateTime)
    {
        var yearInvalid = dateTime.Year < 1970;
        if (yearInvalid)
            throw new ArgumentException("The year cannot be earlier than 1970");

        var unixEpoch = new DateTime(1970, 1, 1);
        return dateTime.Subtract(unixEpoch);
    }
}

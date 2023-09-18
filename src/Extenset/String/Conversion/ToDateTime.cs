namespace Extenset;

using System.Globalization;

/// <summary>
/// Extension methods for <see cref="string" />.
/// </summary>
public static partial class StringExtensions
{
    /// <summary>
    /// Converts the <see cref="string" /> to a <see cref="DateTime" /> value using invariant culture.
    /// </summary>
    /// <param name="dateTimeString">The <see cref="string" /> to convert.</param>
    /// <returns>The <see cref="DateTime" /> value generated from the <see cref="string" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="dateTimeString" /> is <c>null</c>.</exception>
    /// <exception cref="FormatException">Invalid date time string format.</exception>
    public static DateTime ToDateTime(this string dateTimeString)
    {
        if (dateTimeString is null) throw new ArgumentNullException(nameof(dateTimeString));

        var parsed = DateTime.TryParse(
            dateTimeString,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out var dateTime);

        return parsed
            ? dateTime
            : throw new FormatException($"Invalid date time string format: '{dateTimeString}'.");
    }

    /// <summary>
    /// Converts the <see cref="string" /> to a <see cref="DateTime" /> value with the specified
    /// format using invariant culture.
    /// </summary>
    /// <param name="dateTimeString">The <see cref="string" /> to convert.</param>
    /// <param name="format">The date and time format representation contained in the string.</param>
    /// <returns>The <see cref="DateTime" /> value generated from the <see cref="string" />.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="dateTimeString" /> or <paramref name="format" /> is <c>null</c>.
    /// </exception>
    /// <exception cref="FormatException">Invalid date time string format.</exception>
    public static DateTime ToDateTime(this string dateTimeString, string format)
    {
        if (dateTimeString is null) throw new ArgumentNullException(nameof(dateTimeString));
        if (format is null) throw new ArgumentNullException(nameof(format));

        var parsed = DateTime.TryParseExact(
            dateTimeString,
            format,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out var dateTime);

        return parsed
            ? dateTime
            : throw new FormatException($"Invalid date time string format: '{dateTimeString}'.");
    }
}

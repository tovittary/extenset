namespace Extenset;

/// <summary>
/// Extension methods for <see cref="string" />.
/// </summary>
public static partial class StringExtensions
{
    /// <summary>
    /// Converts the <see cref="string" /> to a <see cref="long" /> value.
    /// </summary>
    /// <param name="longString">The <see cref="string" /> to convert.</param>
    /// <returns>The <see cref="long" /> value generated from the <see cref="string" />.</returns>
    /// <exception cref="ArgumentException"><paramref name="longString" /> is <c>null</c>.</exception>
    /// <exception cref="FormatException">Invalid integer string format.</exception>
    public static long ToLong(this string longString)
    {
        if (longString is null) throw new ArgumentNullException(nameof(longString));

        var longParsed = long.TryParse(longString, out var result);
        return longParsed
            ? result
            : throw new FormatException($"Invalid integer string format: '{longString}'.");
    }
}

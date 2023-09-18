namespace Extenset;

/// <summary>
/// Extension methods for <see cref="string" />.
/// </summary>
public static partial class StringExtensions
{
    /// <summary>
    /// Returns a value indicating whether the end of the string matches
    /// the specified substring. String comparison is culture invariant and case insensitive.
    /// </summary>
    /// <param name="string">
    /// The <see cref="string" /> whose end is to be compared with the specified substring.
    /// </param>
    /// <param name="value">The substring to compare to the end of the string.</param>
    /// <returns>
    /// <c>true</c> if the specified substring matches the end of the string;
    /// otherwise <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="string" /> or <paramref name="value" /> is <c>null</c>.
    /// </exception>
    public static bool EndsWithIgnoreCase(this string @string, string value)
    {
        if (@string is null) throw new ArgumentNullException(nameof(@string));
        if (value is null) throw new ArgumentNullException(nameof(value));

        return @string.EndsWith(value, StringComparison.InvariantCultureIgnoreCase);
    }
}

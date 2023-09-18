namespace Extenset;

/// <summary>
/// Extension methods for <see cref="string" />.
/// </summary>
public static partial class StringExtensions
{
    /// <summary>
    /// Returns a value indicating whether the specified value occurs withing the string.
    /// String comparison is culture invariant and case insensitive.
    /// </summary>
    /// <param name="string">The <see cref="string" /> to seek the substring in.</param>
    /// <param name="value">The substring to seek.</param>
    /// <returns>
    /// <c>true</c> if the value occurs within this string,
    /// or if value is the empty string (""); otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="string" /> or <paramref name="value" /> is <c>null</c>.
    /// </exception>
    public static bool ContainsIgnoreCase(this string @string, string value)
    {
        if (@string is null) throw new ArgumentNullException(nameof(@string));
        if (value is null) throw new ArgumentNullException(nameof(value));

        return @string.IndexOf(value, StringComparison.InvariantCultureIgnoreCase) > -1;
    }
}

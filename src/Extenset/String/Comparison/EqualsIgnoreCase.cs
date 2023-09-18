namespace Extenset;

/// <summary>
/// Extension methods for <see cref="string" />.
/// </summary>
public static partial class StringExtensions
{
    /// <summary>
    /// Returns a value indicating whether the string and the value parameter have the same value.
    /// String comparison is culture invariant and case insensitive.
    /// </summary>
    /// <param name="string">The <see cref="string" /> to compare.</param>
    /// <param name="value">The other string to compare.</param>
    /// <returns>
    /// <c>true</c> if the value of the value parameter is the same as string;
    /// otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="string" /> or <paramref name="value" /> is <c>null</c>.
    /// </exception>
    public static bool EqualsIgnoreCase(this string @string, string value)
    {
        if (@string is null) throw new ArgumentNullException(nameof(@string));
        if (value is null) throw new ArgumentNullException(nameof(value));

        return @string.Equals(value, StringComparison.InvariantCultureIgnoreCase);
    }
}

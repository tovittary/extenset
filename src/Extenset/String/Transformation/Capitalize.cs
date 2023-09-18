namespace Extenset;

/// <summary>
/// Extension methods for <see cref="string" />.
/// </summary>
public static partial class StringExtensions
{
    private const char UniversalDirectorySeparator = '/';

    private const char WindowsDirectorySeparator = '\\';

    /// <summary>
    /// Returns a copy of the string converted to lowercase with the first letter capitalized.
    /// </summary>
    /// <param name="string">The <see cref="string" /> to modify.</param>
    /// <returns>A capitalized string.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="string" /> is <c>null</c>.</exception>
    public static string Capitalize(this string @string)
    {
        if (@string is null) throw new ArgumentNullException(nameof(@string));
        if (string.IsNullOrWhiteSpace(@string)) return @string;

        var firstChar = char.ToUpperInvariant(@string[0]);
        var trimmedString = @string.Substring(1).ToLowerInvariant();

        return $"{firstChar}{trimmedString}";
    }
}

namespace Extenset;

/// <summary>
/// Extension methods for <see cref="string" />.
/// </summary>
public partial class StringExtensions
{
    /// <summary>
    /// Indicates whether the <see cref="string" /> is null, empty, or consists only of
    /// white-space characters.
    /// </summary>
    /// <param name="string">The <see cref="string" /> to check.</param>
    /// <returns>
    /// <c>true</c> if the string is null or empty, or if the string consists only of white-space characters,
    /// otherwise <c>false</c>.
    /// </returns>
    public static bool IsNullOrWhitespace(this string? @string) => string.IsNullOrWhiteSpace(@string);
}

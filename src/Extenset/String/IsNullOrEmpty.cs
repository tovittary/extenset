namespace Extenset;

/// <summary>
/// Extension methods for <see cref="string" />.
/// </summary>
public partial class StringExtensions
{
    /// <summary>
    /// Indicates whether the <see cref="string" /> is null or an empty string.
    /// </summary>
    /// <param name="string">The <see cref="string" /> to check.</param>
    /// <returns><c>true</c> if the string is null or empty, otherwise <c>false</c>.</returns>
    public static bool IsNullOrEmpty(this string? @string) => string.IsNullOrEmpty(@string);
}

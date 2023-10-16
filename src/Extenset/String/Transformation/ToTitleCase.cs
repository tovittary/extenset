namespace Extenset;

using System.Globalization;

/// <summary>
/// Extension methods for <see cref="string" />.
/// </summary>
public static partial class StringExtensions
{
    /// <summary>
    /// Returns a copy of the <see cref="string" /> in a title case using an invariant culture.
    /// </summary>
    /// <param name="string">The <see cref="string" /> to modify.</param>
    /// <returns>The <see cref="string" /> in a title case.</returns>
    /// <seealso cref="ToTitleCase(string,CultureInfo)" />
    public static string ToTitleCase(this string @string) =>
        @string.ToTitleCase(CultureInfo.InvariantCulture);

    /// <summary>
    /// Returns a copy of the <see cref="string" /> in a title case.
    /// </summary>
    /// <param name="string">The <see cref="string" /> to modify.</param>
    /// <param name="cultureInfo">The culture to be used to modify the <see cref="string" />.</param>
    /// <returns>The <see cref="string" /> in a title case.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="string" /> is <c>null</c>.</exception>
    public static string ToTitleCase(this string @string, CultureInfo cultureInfo)
    {
        if (@string is null) throw new ArgumentNullException(nameof(@string));
        return cultureInfo.TextInfo.ToTitleCase(@string);
    }
}

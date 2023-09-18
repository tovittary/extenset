namespace Extenset;

using System.Text.RegularExpressions;

/// <summary>
/// Extension methods for <see cref="string" />.
/// </summary>
public static partial class StringExtensions
{
    private const string DefaultBase64DataPrefix = "data:;base64,";

    private static readonly Regex Base64DataPrefixRegex = new(
        "^data:[a-zA-Z/]*?;base64,",
        RegexOptions.IgnoreCase | RegexOptions.Singleline);

    /// <summary>
    /// Returns a copy of the <see cref="string" /> containing base64 with the default data prefix.
    /// </summary>
    /// <param name="base64">The <see cref="string" /> containing base64 to modify.</param>
    /// <returns>The <see cref="string" /> containing base64 with the default data prefix.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="base64" /> is <c>null</c>.</exception>
    public static string AddBase64DataPrefix(this string base64)
    {
        if (base64 is null) throw new ArgumentNullException(nameof(base64));
        return Base64DataPrefixRegex.IsMatch(base64) ? base64 : $"{DefaultBase64DataPrefix}{base64}";
    }
}

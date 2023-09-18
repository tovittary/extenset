namespace Extenset;

/// <summary>
/// Extension methods for <see cref="string" />.
/// </summary>
public static partial class StringExtensions
{
    /// <summary>
    /// Returns a copy of the <see cref="string" /> containing base64 without a data prefix.
    /// </summary>
    /// <param name="base64">The <see cref="string" /> containing base64 to modify.</param>
    /// <returns>The <see cref="string" /> containing base64 without a data prefix.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="base64" /> is <c>null</c>.</exception>
    public static string RemoveBase64DataPrefix(this string base64)
    {
        if (base64 is null) throw new ArgumentNullException(nameof(base64));

        return !Base64DataPrefixRegex.IsMatch(base64)
            ? base64
            : Base64DataPrefixRegex.Replace(base64, string.Empty);
    }
}

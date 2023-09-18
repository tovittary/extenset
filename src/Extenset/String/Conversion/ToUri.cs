namespace Extenset;

/// <summary>
/// Extension methods for <see cref="string" />.
/// </summary>
public static partial class StringExtensions
{
    /// <summary>
    /// Converts the <see cref="string" /> to a new <see cref="Uri" /> object
    /// with an absolute or a relative URI.
    /// </summary>
    /// <param name="uriString">The <see cref="string" /> to convert.</param>
    /// <returns>The <see cref="Uri" /> object generated from the <see cref="string" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="uriString" /> is <c>null</c>.</exception>
    public static Uri ToUri(this string uriString)
    {
        if (uriString is null) throw new ArgumentNullException(nameof(uriString));

        var escaped = Uri.EscapeUriString(uriString);
        var isAbsolute = Uri.IsWellFormedUriString(escaped, UriKind.Absolute);

        return isAbsolute ? ToAbsoluteUri(uriString) : ToRelativeUri(uriString);
    }
}

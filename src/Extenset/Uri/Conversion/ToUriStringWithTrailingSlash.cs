namespace Extenset;

/// <summary>
/// Extension methods for <see cref="Uri" />.
/// </summary>
public static partial class UriExtensions
{
    /// <summary>
    /// Converts the <see cref="Uri" /> to a URI string with a trailing slash.
    /// </summary>
    /// <param name="uri">The <see cref="Uri" /> to convert.</param>
    /// <returns>
    /// The URI string with a trailing slash generated from the <see cref="Uri" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="uri" /> is <c>null</c>.</exception>
    public static string ToUriStringWithTrailingSlash(this Uri uri)
    {
        var uriString = ToUriString(uri);
        return $"{uriString}{UriSegmentSeparator}";
    }
}

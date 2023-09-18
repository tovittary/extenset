namespace Extenset;

/// <summary>
/// Extension methods for <see cref="Uri" />.
/// </summary>
public static partial class UriExtensions
{
    /// <summary>
    /// Converts the <see cref="Uri" /> to a URI string.
    /// </summary>
    /// <param name="uri">The <see cref="Uri" /> to convert.</param>
    /// <returns>The URI string generated from the <see cref="Uri" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="uri" /> is <c>null</c>.</exception>
    public static string ToUriString(this Uri uri)
    {
        if (uri is null) throw new ArgumentNullException(nameof(uri));

        var isAbsoluteUri = TryCreateAbsoluteUriString(uri, out var uriString);
        if (!isAbsoluteUri)
            uriString = CreateRelativeUriString(uri);

        return uriString;
    }

    private static string CreateRelativeUriString(Uri uri)
    {
        var uriString = uri.OriginalString.Trim(UriSegmentSeparator);
        return string.IsNullOrWhiteSpace(uriString) ? string.Empty : $"{UriSegmentSeparator}{uriString}";
    }

    private static bool TryCreateAbsoluteUriString(Uri uri, out string uriString)
    {
        if (!uri.IsAbsoluteUri)
        {
            uriString = string.Empty;
            return false;
        }

        uriString = uri.AbsoluteUri.TrimEnd(UriSegmentSeparator);
        return true;
    }
}

namespace Extenset;

/// <summary>
/// Extension methods for <see cref="Uri" />.
/// </summary>
public static partial class UriExtensions
{
    private const char UriSegmentSeparator = '/';

    /// <summary>
    /// Appends the path to the <see cref="Uri" /> current path.
    /// </summary>
    /// <param name="uri">The <see cref="Uri" /> to modify.</param>
    /// <param name="path">The string containing the path to append.</param>
    /// <returns>The <see cref="Uri" /> with appended path.</returns>
    /// <remarks>If <paramref name="path" /> is null or an empty string, no changes are made.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="uri" /> is <c>null</c>.</exception>
    public static Uri AppendPath(this Uri uri, string? path)
    {
        if (uri is null) throw new ArgumentNullException(nameof(uri));
        if (path is null) return uri;

        return string.IsNullOrWhiteSpace(path) ? uri : AppendPathInternal(uri, path);
    }

    private static Uri AppendPathInternal(Uri uri, string path)
    {
        var builder = new UriBuilder(uri);

        var existingPath = builder.Path.TrimEnd(UriSegmentSeparator);
        var pathToAppend = path.TrimStart(UriSegmentSeparator);

        builder.Path = $"{existingPath}{UriSegmentSeparator}{pathToAppend}";

        return builder.Uri;
    }
}

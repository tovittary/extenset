namespace Extenset;

/// <summary>
/// Extension methods for <see cref="Uri" />.
/// </summary>
public static partial class UriExtensions
{
    /// <summary>
    /// Appends the path with query to the <see cref="Uri" /> current path and query.
    /// </summary>
    /// <param name="uri">The <see cref="Uri" /> to modify.</param>
    /// <param name="pathWithQuery">The string containing the path with the query to append.</param>
    /// <returns>The <see cref="Uri" /> with appended path and query.</returns>
    /// <remarks>
    /// If <paramref name="pathWithQuery" /> is null or an empty string, no changes are made.
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="uri" /> is <c>null</c>.</exception>
    /// <exception cref="FormatException">Invalid path with query string format.</exception>
    public static Uri AppendPathWithQuery(this Uri uri, string? pathWithQuery)
    {
        if (uri is null) throw new ArgumentNullException(nameof(uri));
        if (pathWithQuery is null || string.IsNullOrWhiteSpace(pathWithQuery)) return uri;

        var pathQueryPair = pathWithQuery.Split(QueryIndicators, StringSplitOptions.RemoveEmptyEntries);
        if (pathQueryPair.Length != 2)
            throw new FormatException($"Invalid path with query string format: '{pathWithQuery}'.");

        var path = pathQueryPair[0];
        var query = pathQueryPair[1];

        var withAppendedPath = AppendPathInternal(uri, path);
        return AppendQueryInternal(withAppendedPath, query);
    }
}

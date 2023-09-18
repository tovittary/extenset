namespace Extenset;

/// <summary>
/// Extension methods for <see cref="Uri" />.
/// </summary>
public static partial class UriExtensions
{
    private const char QueryIndicator = '?';

    private const char QuerySeparator = '&';

    private static readonly char[] QueryIndicators = { QueryIndicator };

    /// <summary>
    /// Appends the query to the <see cref="Uri" /> current query.
    /// </summary>
    /// <param name="uri">The <see cref="Uri" /> to modify.</param>
    /// <param name="query">The string containing the query to append.</param>
    /// <returns>The <see cref="Uri" /> with appended query.</returns>
    /// <remarks>If <paramref name="query" /> is null or an empty string, no changes are made.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="uri" /> is <c>null</c>.</exception>
    public static Uri AppendQuery(this Uri uri, string? query)
    {
        if (uri is null) throw new ArgumentNullException(nameof(uri));
        if (query is null) return uri;

        return string.IsNullOrWhiteSpace(query) ? uri : AppendQueryInternal(uri, query);
    }

    private static Uri AppendQueryInternal(Uri uri, string query)
    {
        var builder = new UriBuilder(uri);

        var existingQuery = uri.Query.TrimEnd(QuerySeparator);
        var queryToAppend = query.TrimStart(QueryIndicator, QuerySeparator);

        builder.Query = string.IsNullOrEmpty(existingQuery)
            ? queryToAppend
            : $"{existingQuery}{QuerySeparator}{queryToAppend}";

        return builder.Uri;
    }
}

namespace Extenset;

/// <summary>
/// Extension methods for <see cref="Uri" />.
/// </summary>
public static partial class UriExtensions
{
    /// <summary>
    /// Appends the path with the fragment to the <see cref="Uri" /> current path and fragment.
    /// </summary>
    /// <param name="uri">The <see cref="Uri" /> to modify.</param>
    /// <param name="pathWithFragment">The string containing the path with the fragment to append.</param>
    /// <returns>The <see cref="Uri" /> with appended path and fragment.</returns>
    /// <remarks>
    /// If <paramref name="pathWithFragment" /> is null or an empty string, no changes are made.
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="uri" /> is <c>null</c>.</exception>
    /// <exception cref="FormatException">Invalid path with fragment string format.</exception>
    public static Uri AppendPathWithFragment(this Uri uri, string? pathWithFragment)
    {
        if (uri is null) throw new ArgumentNullException(nameof(uri));
        if (pathWithFragment is null || string.IsNullOrWhiteSpace(pathWithFragment)) return uri;

        var pathFragmentPair = pathWithFragment.Split(
            FragmentIndicators, StringSplitOptions.RemoveEmptyEntries);

        if (pathFragmentPair.Length != 2)
            throw new FormatException($"Invalid path with fragment string format: '{pathWithFragment}'.");

        var path = pathFragmentPair[0];
        var fragment = pathFragmentPair[1];

        var withAppendedPath = AppendPathInternal(uri, path);
        return AppendFragmentInternal(withAppendedPath, fragment);
    }
}

namespace Extenset;

/// <summary>
/// Extension methods for <see cref="Uri" />.
/// </summary>
public static partial class UriExtensions
{
    private const char FragmentIndicator = '#';

    private static readonly char[] FragmentIndicators = { FragmentIndicator };

    /// <summary>
    /// Appends the fragment to the <see cref="Uri" /> current fragment.
    /// </summary>
    /// <param name="uri">The <see cref="Uri" /> to modify.</param>
    /// <param name="fragment">The string containing the fragment to append.</param>
    /// <returns>The <see cref="Uri" /> with appended fragment.</returns>
    /// <remarks>If <paramref name="fragment" /> is null or an empty string, no changes are made.</remarks>
    /// <exception cref="ArgumentNullException"><paramref name="uri" /> is <c>null</c>.</exception>
    public static Uri AppendFragment(this Uri uri, string? fragment)
    {
        if (uri is null) throw new ArgumentNullException(nameof(uri));
        if (fragment is null) return uri;

        return string.IsNullOrWhiteSpace(fragment) ? uri : AppendFragmentInternal(uri, fragment);
    }

    private static Uri AppendFragmentInternal(Uri uri, string fragment)
    {
        var builder = new UriBuilder(uri);

        var existingFragment = builder.Fragment;
        var fragmentToAppend = fragment.TrimStart(FragmentIndicator);

        builder.Fragment = $"{existingFragment}{fragmentToAppend}";

        return builder.Uri;
    }
}

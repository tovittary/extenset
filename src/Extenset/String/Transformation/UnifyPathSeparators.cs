namespace Extenset;

/// <summary>
/// Extension methods for <see cref="string" />.
/// </summary>
public static partial class StringExtensions
{
    private const char UniversalDirectorySeparator = '/';

    private const char WindowsDirectorySeparator = '\\';

    /// <summary>
    /// Returns a copy of the string unified with respect to file system paths.
    /// </summary>
    /// <param name="path">The <see cref="string" /> to modify.</param>
    /// <returns>A unified path string.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="path" /> is <c>null</c>.</exception>
    public static string UnifyPathSeparators(this string path)
    {
        if (path is null) throw new ArgumentNullException(nameof(path));

        return string.IsNullOrWhiteSpace(path)
            ? path
            : path
                .Trim()
                .Replace(UniversalDirectorySeparator, Path.DirectorySeparatorChar)
                .Replace(WindowsDirectorySeparator, Path.DirectorySeparatorChar)
                .Trim(Path.DirectorySeparatorChar);
    }
}

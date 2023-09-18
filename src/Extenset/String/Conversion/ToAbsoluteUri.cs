namespace Extenset;

/// <summary>
/// Extension methods for <see cref="string" />.
/// </summary>
public static partial class StringExtensions
{
    /// <summary>
    /// Converts the <see cref="string" /> to a new <see cref="Uri" /> object with an absolute URI.
    /// </summary>
    /// <param name="uriString">The <see cref="string" /> to convert.</param>
    /// <returns>The <see cref="Uri" /> object generated from the <see cref="string" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="uriString" /> is <c>null</c>.</exception>
    /// <exception cref="FormatException">Invalid URI string format.</exception>
    public static Uri ToAbsoluteUri(this string uriString)
    {
        if (uriString is null) throw new ArgumentNullException(nameof(uriString));

        var trimmed = uriString.Trim().TrimEnd('/');
        return Uri.TryCreate(trimmed, UriKind.Absolute, out var uri)
            ? uri
            : throw new FormatException($"Invalid URI string format: '{uriString}'.");
    }
}

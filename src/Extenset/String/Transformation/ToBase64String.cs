namespace Extenset;

using System.Text;

/// <summary>
/// Extension methods for <see cref="string" />.
/// </summary>
public static partial class StringExtensions
{
    /// <summary>
    /// Generates a Base64 string from the <see cref="string" />.
    /// </summary>
    /// <param name="string">The <see cref="string" /> to generate a Base64 from.</param>
    /// <param name="encoding">
    /// The encoding used to generate a byte array from the <see cref="string" />.
    /// If the parameter value is <c>null</c>, then <see cref="Encoding.UTF8" /> encoding is used.
    /// </param>
    /// <returns>The Base64 string generated from the <see cref="string" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="string" /> is <c>null</c>.</exception>
    public static string ToBase64String(this string @string, Encoding? encoding = null)
    {
        if (@string is null) throw new ArgumentNullException(nameof(@string));

        var encodingToUse = encoding ?? Encoding.UTF8;
        var bytes = encodingToUse.GetBytes(@string);

        return Convert.ToBase64String(bytes);
    }
}

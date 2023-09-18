namespace Extenset;

using System.Globalization;

/// <summary>
/// Extension methods for <see cref="string" />.
/// </summary>
public static partial class StringExtensions
{
    /// <summary>
    /// Converts the <see cref="string" /> to a <see cref="double" /> value using invariant culture.
    /// </summary>
    /// <param name="doubleString">The <see cref="string" /> to convert.</param>
    /// <returns>The <see cref="double" /> value generated from the <see cref="string" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="doubleString" /> is <c>null</c>.</exception>
    /// <exception cref="FormatException">Invalid double string format.</exception>
    public static double ToDoubleInvariant(this string doubleString)
    {
        if (doubleString is null) throw new ArgumentNullException(nameof(doubleString));

        var invariantDoubleStr = doubleString.Replace(',', '.');
        var doubleParsed = double.TryParse(
            invariantDoubleStr,
            NumberStyles.Any,
            CultureInfo.InvariantCulture,
            out var result);

        return doubleParsed
            ? result
            : throw new FormatException($"Invalid double string format: '{doubleString}'.");
    }
}

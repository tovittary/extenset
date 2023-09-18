namespace Extenset;

/// <summary>
/// Extension methods for <see cref="string" />.
/// </summary>
public static partial class StringExtensions
{
    /// <summary>
    /// Converts the <see cref="string" /> to an <see cref="int" /> value.
    /// </summary>
    /// <param name="intString">The <see cref="string" /> to convert.</param>
    /// <returns>The <see cref="int" /> value generated from the <see cref="string" />.</returns>
    /// <exception cref="ArgumentException"><paramref name="intString" /> is <c>null</c>.</exception>
    /// <exception cref="FormatException">Invalid integer string format.</exception>
    public static int ToInt(this string intString)
    {
        if (intString is null) throw new ArgumentNullException(nameof(intString));

        var intParsed = int.TryParse(intString, out var result);
        return intParsed
            ? result
            : throw new FormatException($"Invalid integer string format: '{intString}'.");
    }
}

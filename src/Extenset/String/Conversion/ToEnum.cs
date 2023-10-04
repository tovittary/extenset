namespace Extenset;

/// <summary>
/// Extension methods for <see cref="string" />.
/// </summary>
public partial class StringExtensions
{
    /// <summary>
    /// Converts the <see cref="string" /> to a enum value.
    /// </summary>
    /// <param name="enumString">The <see cref="string" /> to convert.</param>
    /// <param name="ignoreCase">Indicates whether to ignore case.</param>
    /// <typeparam name="T">A type of enum.</typeparam>
    /// <returns>The enum value generated from <see cref="string" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="enumString" /> is null.</exception>
    /// <seealso cref="Enum.Parse(System.Type,string,bool)" />
    public static T ToEnum<T>(this string enumString, bool ignoreCase = false)
        where T : struct
    {
        if (enumString is null) throw new ArgumentNullException(nameof(enumString));
        return (T)Enum.Parse(typeof(T), enumString, ignoreCase);
    }
}

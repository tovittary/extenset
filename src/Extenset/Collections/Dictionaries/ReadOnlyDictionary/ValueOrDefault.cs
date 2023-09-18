namespace Extenset;

/// <summary>
/// Extension methods for <see cref="IReadOnlyDictionary{TKey,TValue}" />.
/// </summary>
public static partial class DictionaryExtensions
{
    /// <summary>
    /// Returns a value that is associated with the specified key, or a default value if no such value
    /// is found.
    /// </summary>
    /// <param name="source">The <see cref="Dictionary{TKey,TValue}" /> to return a value from.</param>
    /// <param name="key">The key to locate in the <see cref="Dictionary{TKey,TValue}" />.</param>
    /// <typeparam name="TKey">The type of keys.</typeparam>
    /// <typeparam name="TValue">The type of values.</typeparam>
    /// <returns>
    /// A value associated with the specified key, if the key is found;
    /// otherwise the default value for the type of the value.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source" /> or <paramref name="key" /> is <c>null</c>.
    /// </exception>
    public static TValue? ValueOrDefault<TKey, TValue>(
        this IReadOnlyDictionary<TKey, TValue> source, TKey key)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        if (key is null) throw new ArgumentNullException(nameof(key));

        return source.TryGetValue(key, out var value) ? value : default;
    }
}

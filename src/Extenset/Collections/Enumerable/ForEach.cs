namespace Extenset;

/// <summary>
/// Extension methods for <see cref="IEnumerable{T}" />.
/// </summary>
public static partial class EnumerableExtensions
{
    /// <summary>
    /// Iterates over each item in the <see cref="IEnumerable{T}" /> and applies
    /// the specified action to each of them.
    /// </summary>
    /// <param name="enumerable">The <see cref="IEnumerable{T}" /> to iterate over.</param>
    /// <param name="action">An action to be applied to items of the <see cref="IEnumerable{T}" />.</param>
    /// <typeparam name="T">The type of items.</typeparam>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="enumerable" /> or <paramref name="action" /> is null.
    /// </exception>
    public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
    {
        if (enumerable is null) throw new ArgumentNullException(nameof(enumerable));
        if (action is null) throw new ArgumentNullException(nameof(action));

        foreach (var item in enumerable)
            action(item);
    }

    /// <summary>
    /// Iterates over each item in the <see cref="IEnumerable{T}" /> and applies
    /// the specified action to each of them.
    /// </summary>
    /// <param name="enumerable">The <see cref="IEnumerable{T}" /> to iterate over.</param>
    /// <param name="action">An action to be applied to items of the <see cref="IEnumerable{T}" />.</param>
    /// <typeparam name="T">The type of items.</typeparam>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="enumerable" /> or <paramref name="action" /> is null.
    /// </exception>
    public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T, int> action)
    {
        if (enumerable is null) throw new ArgumentNullException(nameof(enumerable));
        if (action is null) throw new ArgumentNullException(nameof(action));

        var index = 0;
        foreach (var item in enumerable)
            action(item, index++);
    }
}

namespace Extenset;

/// <summary>
/// Extension methods for <see cref="IEnumerable{T}" />.
/// </summary>
public static partial class EnumerableExtensions
{
    /// <summary>
    /// Indicates whether the specified <see cref="IEnumerable{T}" /> is null or contains no items.
    /// </summary>
    /// <param name="enumerable">The <see cref="IEnumerable{T}" /> to check.</param>
    /// <typeparam name="T">The type of items.</typeparam>
    /// <returns>
    /// <c>true</c> if the <see cref="IEnumerable{T}" /> is <c>null</c> or empty; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? enumerable) =>
        enumerable is null || !enumerable.Any();
}

namespace Extenset;

/// <summary>
/// Extension methods for <see cref="IEnumerable{T}" />.
/// </summary>
public static partial class EnumerableExtensions
{
    /// <summary>
    /// Asynchronously iterates over each item in the <see cref="IEnumerable{T}" /> and applies
    /// the specified asynchronous function to each of them.
    /// </summary>
    /// <param name="enumerable">The <see cref="IEnumerable{T}" /> to iterate over.</param>
    /// <param name="asyncFunction">
    /// An asynchronous function to be applied to items of the <see cref="IEnumerable{T}" />.
    /// </param>
    /// <typeparam name="T">The type of items.</typeparam>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="enumerable" /> or <paramref name="asyncFunction" /> is null.
    /// </exception>
    /// <returns>
    /// The <see cref="Task" /> that represents the asynchronous enumerable iteration operation.
    /// </returns>
    public static async Task ForEachAsync<T>(this IEnumerable<T> enumerable, Func<T, Task> asyncFunction)
    {
        if (enumerable is null) throw new ArgumentNullException(nameof(enumerable));
        if (asyncFunction is null) throw new ArgumentNullException(nameof(asyncFunction));

        foreach (var item in enumerable)
            await asyncFunction(item).ConfigureAwait(false);
    }

    /// <summary>
    /// Asynchronously iterates over each item in the <see cref="IEnumerable{T}" /> and applies
    /// the specified asynchronous function to each of them.
    /// </summary>
    /// <param name="enumerable">The <see cref="IEnumerable{T}" /> to iterate over.</param>
    /// <param name="asyncFunction">
    /// An asynchronous function to be applied to items of the <see cref="IEnumerable{T}" />.
    /// </param>
    /// <typeparam name="T">The type of items.</typeparam>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="enumerable" /> or <paramref name="asyncFunction" /> is null.
    /// </exception>
    /// <returns>
    /// The <see cref="Task" /> that represents the asynchronous enumerable iteration operation.
    /// </returns>
    public static async Task ForEachAsync<T>(
        this IEnumerable<T> enumerable,
        Func<T, int, Task> asyncFunction)
    {
        if (enumerable is null) throw new ArgumentNullException(nameof(enumerable));
        if (asyncFunction is null) throw new ArgumentNullException(nameof(asyncFunction));

        var index = 0;
        foreach (var item in enumerable)
            await asyncFunction(item, index++).ConfigureAwait(false);
    }

    /// <summary>
    /// Asynchronously iterates over each item in the <see cref="IEnumerable{T}" /> and applies
    /// the specified asynchronous function to each of them with the cancellation support.
    /// </summary>
    /// <param name="enumerable">The <see cref="IEnumerable{T}" /> to iterate over.</param>
    /// <param name="asyncFunction">
    /// An asynchronous function to be applied to items of the <see cref="IEnumerable{T}" />.
    /// </param>
    /// <param name="cancellationToken">Notifies of the cancellation of the execution.</param>
    /// <typeparam name="T">The type of items.</typeparam>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="enumerable" /> or <paramref name="asyncFunction" /> is null.
    /// </exception>
    /// <returns>
    /// The <see cref="Task" /> that represents the asynchronous enumerable iteration operation.
    /// </returns>
    public static async Task ForEachAsync<T>(
        this IEnumerable<T> enumerable,
        Func<T, CancellationToken, Task> asyncFunction,
        CancellationToken cancellationToken)
    {
        if (enumerable is null) throw new ArgumentNullException(nameof(enumerable));
        if (asyncFunction is null) throw new ArgumentNullException(nameof(asyncFunction));

        foreach (var item in enumerable)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await asyncFunction(item, cancellationToken).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Asynchronously iterates over each item in the <see cref="IEnumerable{T}" /> and applies
    /// the specified asynchronous function to each of them with the cancellation support.
    /// </summary>
    /// <param name="enumerable">The <see cref="IEnumerable{T}" /> to iterate over.</param>
    /// <param name="asyncFunction">
    /// An asynchronous function to be applied to items of the <see cref="IEnumerable{T}" />.
    /// </param>
    /// <param name="cancellationToken">Notifies of the cancellation of the execution.</param>
    /// <typeparam name="T">The type of items.</typeparam>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="enumerable" /> or <paramref name="asyncFunction" /> is null.
    /// </exception>
    /// <returns>
    /// The <see cref="Task" /> that represents the asynchronous enumerable iteration operation.
    /// </returns>
    public static async Task ForEachAsync<T>(
        this IEnumerable<T> enumerable,
        Func<T, int, CancellationToken, Task> asyncFunction,
        CancellationToken cancellationToken)
    {
        if (enumerable is null) throw new ArgumentNullException(nameof(enumerable));
        if (asyncFunction is null) throw new ArgumentNullException(nameof(asyncFunction));

        var index = 0;
        foreach (var item in enumerable)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await asyncFunction(item, index++, cancellationToken).ConfigureAwait(false);
        }
    }
}

namespace Extenset.Tests;

internal sealed partial class EnumerableExtensionsTests
{
    private static readonly Action<string> EmptyAction = _ => { };

    private static readonly Action<string, int> EmptyActionWithIndex = (_, _) => { };

    private static readonly string[] EmptyEnumerable = Array.Empty<string>();

    private static readonly Func<string, Task> EmptyFunction = _ => Task.CompletedTask;

    private static readonly Func<string, CancellationToken, Task> EmptyFunctionWithCancellation =
        (_, _) => Task.CompletedTask;

    private static readonly Func<string, int, Task> EmptyFunctionWithIndex = (_, _) => Task.CompletedTask;

    private static readonly Func<string, int, CancellationToken, Task>
        EmptyFunctionWithIndexAndCancellation = (_, _, _) => Task.CompletedTask;

    private static readonly Action<string>? NullAction = null;

    private static readonly Action<string, int>? NullActionWithIndex = null;

    private static readonly string[]? NullEnumerable = null;

    private static readonly Func<string, Task>? NullFunction = null;

    private static readonly Func<string, CancellationToken, Task>? NullFunctionWithCancellation = null;

    private static readonly Func<string, int, Task>? NullFunctionWithIndex = null;

    private static readonly Func<string, int, CancellationToken, Task>?
        NullFunctionWithIndexAndCancellation = null;

    private static readonly string[] StringEnumerable = { "1", "2", "3", "4", "5" };
}

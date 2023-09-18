namespace Extenset.Tests;

[TestFixture]
internal sealed partial class EnumerableExtensionsTests
{
    [Test]
    public void ForEachAsync_Cancelled_ShouldThrow()
    {
        // Arrange
        using var cts = new CancellationTokenSource();

        // Act
        cts.Cancel();

        // Assert
        Assert.ThrowsAsync(
            Is.TypeOf<TaskCanceledException>().Or.TypeOf<OperationCanceledException>(),
            () => StringEnumerable.ForEachAsync((_, token) => Task.Delay(1, token), cts.Token));

        Assert.ThrowsAsync(
            Is.TypeOf<TaskCanceledException>().Or.TypeOf<OperationCanceledException>(),
            () => StringEnumerable.ForEachAsync((_, _, token) => Task.Delay(1, token), cts.Token));
    }

    [Test]
    public void ForEachAsync_EnumerableNull_ShouldThrow()
    {
        // Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => NullEnumerable!.ForEachAsync(EmptyFunction));
        Assert.ThrowsAsync<ArgumentNullException>(() => NullEnumerable!.ForEachAsync(EmptyFunctionWithIndex));
        Assert.ThrowsAsync<ArgumentNullException>(() =>
            NullEnumerable!.ForEachAsync(EmptyFunctionWithCancellation, CancellationToken.None));

        Assert.ThrowsAsync<ArgumentNullException>(() =>
            NullEnumerable!.ForEachAsync(EmptyFunctionWithIndexAndCancellation, CancellationToken.None));
    }

    [Test]
    public void ForEachAsync_FunctionNull_ShouldThrow()
    {
        // Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => StringEnumerable.ForEachAsync(NullFunction!));
        Assert.ThrowsAsync<ArgumentNullException>(() =>
            StringEnumerable.ForEachAsync(NullFunctionWithIndex!));

        Assert.ThrowsAsync<ArgumentNullException>(() =>
            StringEnumerable.ForEachAsync(NullFunctionWithCancellation!, CancellationToken.None));

        Assert.ThrowsAsync<ArgumentNullException>(() =>
            StringEnumerable.ForEachAsync(NullFunctionWithIndexAndCancellation!, CancellationToken.None));
    }

    [Test]
    public async Task ForEachAsync_FunctionSimple_ShouldApplyFunction()
    {
        // Act
        var actual = new List<string>(StringEnumerable.Length);
        await StringEnumerable.ForEachAsync(async item =>
        {
            await Task.Delay(1);
            actual.Add(item);
        });

        // Assert
        for (var i = 0; i < StringEnumerable.Length; i++)
            Assert.AreEqual(StringEnumerable[i], actual[i]);
    }

    [Test]
    public async Task ForEachAsync_FunctionWithCancellation_ShouldApplyFunction()
    {
        // Act
        var actual = new List<string>(StringEnumerable.Length);
        await StringEnumerable.ForEachAsync(
            async (item, token) =>
            {
                await Task.Delay(1, token);
                actual.Add(item);
            },
            CancellationToken.None);

        // Assert
        for (var i = 0; i < StringEnumerable.Length; i++)
            Assert.AreEqual(StringEnumerable[i], actual[i]);
    }

    [Test]
    public async Task ForEachAsync_FunctionWithIndex_ShouldApplyFunction()
    {
        // Act
        var actual = new string[StringEnumerable.Length];
        await StringEnumerable.ForEachAsync(async (item, index) =>
        {
            await Task.Delay(1);
            actual[index] = item;
        });

        // Assert
        for (var i = 0; i < StringEnumerable.Length; i++)
            Assert.AreEqual(StringEnumerable[i], actual[i]);
    }

    [Test]
    public async Task ForEachAsync_FunctionWithIndexAndCancellation_ShouldApplyFunction()
    {
        // Act
        var actual = new string[StringEnumerable.Length];
        await StringEnumerable.ForEachAsync(
            async (item, index, token) =>
            {
                await Task.Delay(1, token);
                actual[index] = item;
            },
            CancellationToken.None);

        // Assert
        for (var i = 0; i < StringEnumerable.Length; i++)
            Assert.AreEqual(StringEnumerable[i], actual[i]);
    }
}

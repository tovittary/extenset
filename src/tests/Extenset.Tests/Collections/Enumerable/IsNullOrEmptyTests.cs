namespace Extenset.Tests;

[TestFixture]
internal sealed partial class EnumerableExtensionsTests
{
    [Test]
    public void IsNullOrEmpty_EnumerableNotEmpty_ShouldReturnFalse()
    {
        // Act
        var actual = StringEnumerable.IsNullOrEmpty();

        // Assert
        Assert.False(actual);
    }

    [Test]
    public void IsNullOrEmpty_EnumerableNullOrEmpty_ShouldReturnTrue()
    {
        // Act
        var actualOnEmpty = EmptyEnumerable.IsNullOrEmpty();
        var actualOnNull = NullEnumerable.IsNullOrEmpty();

        // Assert
        Assert.True(actualOnEmpty);
        Assert.True(actualOnNull);
    }
}

namespace Extenset.Tests;

[TestFixture]
internal sealed partial class StringExtensionsTests
{
    [Test]
    public void UnifyPathSeparators_StringEmpty_ShouldReturnWithoutChanges()
    {
        // Arrange
        var @string = string.Empty;

        // Act
        var actual = @string.UnifyPathSeparators();

        // Assert
        Assert.AreEqual(@string, actual);
    }

    [Test]
    public void UnifyPathSeparators_StringNull_ShouldThrow()
    {
        // Arrange
        string? nullString = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => nullString!.UnifyPathSeparators());
    }

    [Test]
    public void UnifyPathSeparators_StringValid_ShouldReturnUnified()
    {
        // Arrange
        const string first = "/root/path/file.extension";
        const string second = @"\root\path\file.extension";

        // Act
        var firstActual = first.UnifyPathSeparators();
        var secondActual = second.UnifyPathSeparators();

        // Assert
        Assert.AreEqual(firstActual, secondActual);
    }
}

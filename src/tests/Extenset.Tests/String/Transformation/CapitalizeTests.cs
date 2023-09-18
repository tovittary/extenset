namespace Extenset.Tests;

[TestFixture]
internal sealed partial class StringExtensionsTests
{
    [Test]
    public void Capitalize_StringEmpty_ShouldReturnWithoutChanges()
    {
        // Arrange
        var @string = string.Empty;

        // Act
        var actual = @string.Capitalize();

        // Assert
        Assert.AreEqual(@string, actual);
    }

    [Test]
    public void Capitalize_StringNull_ShouldThrow()
    {
        // Arrange
        string? nullString = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => nullString!.Capitalize());
    }

    [Test]
    public void Capitalize_StringValid_ShouldReturnCapitalized()
    {
        // Arrange
        const string expected = "Test";
        const string @string = "test";

        // Act
        var actual = @string.Capitalize();

        // Assert
        Assert.AreEqual(expected, actual);
    }
}

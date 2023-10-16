namespace Extenset.Tests;

using System.Globalization;

[TestFixture]
internal sealed partial class StringExtensionsTests
{
    [Test]
    public void ToTitleCase_CustomCulture_ShouldReturnCapitalized()
    {
        // Arrange
        const string expected = "İstanbul";
        const string @string = "istanbul";

        // Act
        var actual = @string.ToTitleCase(new CultureInfo("tr-TR"));

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ToTitleCase_StringEmpty_ShouldReturnWithoutChanges()
    {
        // Arrange
        var @string = string.Empty;

        // Act
        var actual = @string.ToTitleCase();

        // Assert
        Assert.AreEqual(@string, actual);
    }

    [Test]
    public void ToTitleCase_StringNull_ShouldThrow()
    {
        // Arrange
        string? nullString = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => nullString!.ToTitleCase());
    }

    [Test]
    public void ToTitleCase_StringValid_ShouldReturnCapitalized()
    {
        // Arrange
        const string expected = "Test String";
        const string @string = "test string";

        // Act
        var actual = @string.ToTitleCase();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ToTitleCase_WithAcronym_ShouldReturnCapitalized()
    {
        // Arrange
        const string expected = "Example Of NASA";
        const string @string = "example of NASA";

        // Act
        var actual = @string.ToTitleCase();

        // Assert
        Assert.AreEqual(expected, actual);
    }
}

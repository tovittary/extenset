namespace Extenset.Tests;

using System.Text;

internal sealed partial class StringExtensionsTests
{
    [Test]
    public void ToBase64String_StringEmpty_ShouldReturnEmptyString()
    {
        // Arrange
        var expected = string.Empty;
        var emptyString = string.Empty;

        // Act
        var actual = emptyString.ToBase64String();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ToBase64String_StringNull_ShouldThrow()
    {
        // Arrange
        string? nullString = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => nullString!.ToBase64String());
    }

    [Test]
    public void ToBase64String_Utf16Encoding_ShouldReturnUtf16Base64String()
    {
        // Arrange
        const string expected = "dABlAHMAdAAgAHMAdAByAGkAbgBnAA==";
        const string @string = "test string";

        // Act
        var actual = @string.ToBase64String(Encoding.Unicode);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ToBase64String_ValidString_ShouldReturnUtf8Base64String()
    {
        // Arrange
        const string expected = "dGVzdCBzdHJpbmc=";
        const string @string = "test string";

        // Act
        var actual = @string.ToBase64String();

        // Assert
        Assert.AreEqual(expected, actual);
    }
}

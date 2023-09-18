namespace Extenset.Tests;

[TestFixture]
internal sealed partial class StringExtensionsTests
{
    [TestCase("/9j/4AAQSk")]
    [TestCase("iVBORw0KGk")]
    [TestCase("JIBERi0xLj")]
    public void RemoveBase64DataPrefix_AlreadyWithoutPrefix_ShouldReturnWithoutChanges(string base64)
    {
        // Act
        var actual = base64.RemoveBase64DataPrefix();

        // Assert
        Assert.AreEqual(base64, actual);
    }

    [Test]
    public void RemoveBase64DataPrefix_StringNull_ShouldThrow()
    {
        // Arrange
        string? nullString = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => nullString!.RemoveBase64DataPrefix());
    }

    [TestCase("data:;base64,/9j/4AAQSk", "/9j/4AAQSk")]
    [TestCase("data:application/pdf;base64,JIBERi0xLj", "JIBERi0xLj")]
    [TestCase("data:image/png;base64,iVBORw0KGk", "iVBORw0KGk")]
    public void RemoveBase64DataPrefix_StringValid_ShouldReturnWithoutPrefix(string base64, string expected)
    {
        // Act
        var actual = base64.RemoveBase64DataPrefix();

        // Assert
        Assert.AreEqual(expected, actual);
    }
}

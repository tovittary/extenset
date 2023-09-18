namespace Extenset.Tests;

[TestFixture]
internal sealed partial class StringExtensionsTests
{
    [TestCase("data:;base64,/9j/4AAQSk")]
    [TestCase("data:image/png;base64,iVBORw0KGk")]
    [TestCase("data:application/pdf;base64,JIBERi0xLj")]
    public void AddBase64DataPrefix_AlreadyWithPrefix_ShouldReturnWithoutChanges(string base64)
    {
        // Act
        var actual = base64.AddBase64DataPrefix();

        // Assert
        Assert.AreEqual(base64, actual);
    }

    [Test]
    public void AddBase64DataPrefix_StringNull_ShouldThrow()
    {
        // Arrange
        string? nullString = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => nullString!.AddBase64DataPrefix());
    }

    [TestCase("/9j/4AAQSk", "data:;base64,/9j/4AAQSk")]
    [TestCase("iVBORw0KGk", "data:;base64,iVBORw0KGk")]
    [TestCase("JIBERi0xLj", "data:;base64,JIBERi0xLj")]
    public void AddBase64DataPrefix_StringValid_ShouldReturnWithPrefix(string base64, string expected)
    {
        // Act
        var actual = base64.AddBase64DataPrefix();

        // Assert
        Assert.AreEqual(expected, actual);
    }
}

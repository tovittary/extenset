namespace Extenset.Tests;

[TestFixture]
internal sealed partial class StringExtensionsTests
{
    [TestCase("")]
    [TestCase("/")]
    [TestCase("/path")]
    [TestCase("/pathAndQuery?query=test")]
    [TestCase("file:///C:/folder/file.ext")]
    [TestCase("https://file:///C:/folder/file.ext")]
    [TestCase("https://localhost")]
    [TestCase("https://localhost/")]
    [TestCase("https://localhost/path")]
    [TestCase("https://localhost/path/")]
    [TestCase("https://localhost/path?query=test")]
    [TestCase("https://localhost/path?query=test/")]
    [TestCase("https://localhost:5000")]
    [TestCase("https://localhost:5000/")]
    [TestCase("path")]
    [TestCase("pathAndQuery?query=test")]
    public void ToUri_ShouldReturnUri(string uriString)
    {
        // Act
        var actual = uriString.ToUri();

        // Assert
        Assert.NotNull(actual);
    }

    [Test]
    public void ToUri_StringNull_ShouldThrow()
    {
        // Arrange
        string? nullString = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => nullString!.ToUri());
    }
}

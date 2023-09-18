namespace Extenset.Tests;

[TestFixture]
internal sealed partial class StringExtensionsTests
{
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
    public void ToRelativeUri_InvalidFormat_ShouldThrow(string uriString) =>
        Assert.Throws<FormatException>(() => uriString.ToRelativeUri());

    [Test]
    public void ToRelativeUri_StringNull_ShouldThrow()
    {
        // Arrange
        string? nullString = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => nullString!.ToRelativeUri());
    }

    [TestCase("")]
    [TestCase("/")]
    [TestCase("/path")]
    [TestCase("/pathAndQuery?query=test")]
    [TestCase("path")]
    [TestCase("pathAndQuery?query=test")]
    public void ToRelativeUri_ValidFormat_ShouldReturnUri(string uriString)
    {
        // Act
        var actual = uriString.ToRelativeUri();

        // Assert
        Assert.NotNull(actual);
    }
}

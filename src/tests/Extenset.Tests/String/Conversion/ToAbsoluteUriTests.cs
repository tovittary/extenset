namespace Extenset.Tests;

[TestFixture]
internal sealed partial class StringExtensionsTests
{
    [TestCase("")]
    [TestCase("/")]
    [TestCase("/path")]
    [TestCase("/pathAndQuery?query=test")]
    [TestCase("https//localhost/path")]
    [TestCase("https://")]
    [TestCase("https:/localhost/path")]
    [TestCase(@"https:\\localhost\\path")]
    [TestCase("https:https://localhost/path")]
    [TestCase("path")]
    [TestCase("pathAndQuery?query=test")]
    public void ToAbsoluteUri_InvalidFormat_ShouldThrow(string uriString) =>
        Assert.Throws<FormatException>(() => uriString.ToAbsoluteUri());

    [Test]
    public void ToAbsoluteUri_StringNull_ShouldThrow()
    {
        // Arrange
        string? nullString = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => nullString!.ToAbsoluteUri());
    }

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
    public void ToAbsoluteUri_ValidFormat_ShouldReturnUri(string uriString)
    {
        // Act
        var actual = uriString.ToAbsoluteUri();

        // Assert
        Assert.NotNull(actual);
    }
}

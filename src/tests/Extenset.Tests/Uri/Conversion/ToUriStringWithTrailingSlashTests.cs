namespace Extenset.Tests;

[TestFixture]
internal sealed partial class UriExtensionsTests
{
    [TestCase("http://localhost", "http://localhost/")]
    [TestCase("http://localhost/", "http://localhost/")]
    [TestCase("http://localhost:1234", "http://localhost:1234/")]
    [TestCase("http://localhost:1234/", "http://localhost:1234/")]
    [TestCase("http://localhost/path", "http://localhost/path/")]
    [TestCase("http://localhost/path/", "http://localhost/path/")]
    [TestCase("http://localhost/path?query=test", "http://localhost/path?query=test/")]
    [TestCase("http://localhost/path?query=test/", "http://localhost/path?query=test/")]
    public static void ToUriStringWithTrailingSlash_AbsoluteUri_ShouldReturnUriString(
        string uriString, string expected)
    {
        // Arrange
        var uri = new Uri(uriString, UriKind.Absolute);

        // Act
        var actual = uri.ToUriStringWithTrailingSlash();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestCase("", "/")]
    [TestCase("/", "/")]
    [TestCase("path", "/path/")]
    [TestCase("/path", "/path/")]
    [TestCase("/path/", "/path/")]
    [TestCase("path?query=test", "/path?query=test/")]
    [TestCase("/path?query=test", "/path?query=test/")]
    [TestCase("/path?query=test/", "/path?query=test/")]
    public static void ToUriStringWithTrailingSlash_RelativeUri_ShouldReturnUriString(
        string uriString, string expected)
    {
        // Arrange
        var uri = new Uri(uriString, UriKind.Relative);

        // Act
        var actual = uri.ToUriStringWithTrailingSlash();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public static void ToUriStringWithTrailingSlash_UriNull_ShouldThrow()
    {
        // Arrange
        Uri? nullUri = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => nullUri!.ToUriStringWithTrailingSlash());
    }
}

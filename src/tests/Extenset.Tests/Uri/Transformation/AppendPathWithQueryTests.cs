namespace Extenset.Tests;

[TestFixture]
internal sealed partial class UriExtensionsTests
{
    [TestCase("http://localhost", "", "http://localhost/")]
    [TestCase("http://localhost", "/path?query=value", "http://localhost/path?query=value")]
    [TestCase("http://localhost", "path?query", "http://localhost/path?query")]
    [TestCase("http://localhost/path", "", "http://localhost/path")]
    [TestCase("http://localhost/path", "/path?query=value", "http://localhost/path/path?query=value")]
    [TestCase("http://localhost/path", "path?query", "http://localhost/path/path?query")]
    [TestCase("http://localhost:1234", "", "http://localhost:1234/")]
    [TestCase("http://localhost:1234", "/path?query=value", "http://localhost:1234/path?query=value")]
    [TestCase("http://localhost:1234", "path?query", "http://localhost:1234/path?query")]
    public static void AppendPathWithQuery_PathWithQuery_ShouldReturnWithPathWithQuery(
        string uriString,
        string pathWithQuery,
        string expected)
    {
        // Arrange
        var uri = new Uri(uriString, UriKind.Absolute);

        // Act
        var actual = uri.AppendPathWithQuery(pathWithQuery);

        // Assert
        Assert.AreEqual(expected, actual.AbsoluteUri);
    }

    [TestCase("")]
    [TestCase(null)]
    public static void AppendPathWithQuery_PathWithQueryNullOrEmpty_ShouldReturnWithoutChanges(
        string pathWithQuery)
    {
        // Arrange
        const string expected = "http://localhost/path?param=value";
        var uri = new Uri(expected, UriKind.Absolute);

        // Act
        var actual = uri.AppendPathWithQuery(pathWithQuery);

        // Assert
        Assert.AreEqual(expected, actual.AbsoluteUri);
    }

    [Test]
    public static void AppendPathWithQuery_UriNull_ShouldThrow()
    {
        // Arrange
        Uri? nullUri = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => nullUri!.AppendPathWithQuery(string.Empty));
    }
}

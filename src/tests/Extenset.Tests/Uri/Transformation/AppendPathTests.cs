namespace Extenset.Tests;

[TestFixture]
internal sealed partial class UriExtensionsTests
{
    [TestCase(
        "http://localhost/path",
        "/additional",
        "http://localhost/path/additional")]
    [TestCase(
        "http://localhost/path",
        "additional",
        "http://localhost/path/additional")]
    [TestCase(
        "http://localhost/path?query=test",
        "/additional",
        "http://localhost/path/additional?query=test")]
    [TestCase(
        "http://localhost/path?query=test#fragment",
        "/additional",
        "http://localhost/path/additional?query=test#fragment")]
    public static void AppendPath_AlreadyHasPath_ShouldCombinePaths(
        string uriString,
        string path,
        string expected)
    {
        // Arrange
        var uri = new Uri(uriString, UriKind.Absolute);

        // Act
        var actual = uri.AppendPath(path);

        // Assert
        Assert.AreEqual(expected, actual.AbsoluteUri);
    }

    [TestCase("")]
    [TestCase(null)]
    public static void AppendPath_PathNullOrEmpty_ShouldReturnWithoutChanges(string path)
    {
        // Arrange
        const string expected = "http://localhost/path";
        var uri = new Uri(expected, UriKind.Absolute);

        // Act
        var actual = uri.AppendPath(path);

        // Assert
        Assert.AreEqual(expected, actual.AbsoluteUri);
    }

    [TestCase("http://localhost", "", "http://localhost/")]
    [TestCase("http://localhost", "/", "http://localhost/")]
    [TestCase("http://localhost", "/path", "http://localhost/path")]
    [TestCase("http://localhost", "path", "http://localhost/path")]
    [TestCase("http://localhost/path", "", "http://localhost/path")]
    [TestCase("http://localhost/path", "/", "http://localhost/path/")]
    [TestCase("http://localhost/path", "/additional", "http://localhost/path/additional")]
    [TestCase("http://localhost/path", "additional", "http://localhost/path/additional")]
    [TestCase("http://localhost:1234", "", "http://localhost:1234/")]
    [TestCase("http://localhost:1234", "/", "http://localhost:1234/")]
    [TestCase("http://localhost:1234", "/path", "http://localhost:1234/path")]
    [TestCase("http://localhost:1234", "path", "http://localhost:1234/path")]
    public static void AppendPath_PathValid_ShouldReturnWithPath(
        string uriString,
        string path,
        string expected)
    {
        // Arrange
        var uri = new Uri(uriString, UriKind.Absolute);

        // Act
        var actual = uri.AppendPath(path);

        // Assert
        Assert.AreEqual(expected, actual.AbsoluteUri);
    }

    [Test]
    public static void AppendPath_UriNull_ShouldThrow()
    {
        // Arrange
        Uri? nullUri = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => nullUri!.AppendPath(string.Empty));
    }
}

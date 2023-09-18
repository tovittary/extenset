namespace Extenset.Tests;

[TestFixture]
internal sealed partial class UriExtensionsTests
{
    [TestCase(
        "http://localhost/?query=test",
        "&param=value",
        "http://localhost/?query=test&param=value")]
    [TestCase(
        "http://localhost/?query=test",
        "?param=value",
        "http://localhost/?query=test&param=value")]
    [TestCase(
        "http://localhost/?query=test",
        "param=value",
        "http://localhost/?query=test&param=value")]
    [TestCase(
        "http://localhost/path?query=test",
        "param=value",
        "http://localhost/path?query=test&param=value")]
    [TestCase(
        "http://localhost/path?query=test#fragment",
        "param=value",
        "http://localhost/path?query=test&param=value#fragment")]
    public static void AppendQuery_AlreadyHasQuery_ShouldCombineQuery(
        string uriString,
        string query,
        string expected)
    {
        // Arrange
        var uri = new Uri(uriString, UriKind.Absolute);

        // Act
        var actual = uri.AppendQuery(query);

        // Assert
        Assert.AreEqual(expected, actual.AbsoluteUri);
    }

    [TestCase("")]
    [TestCase(null)]
    public static void AppendQuery_QueryNullOrEmpty_ShouldReturnWithoutChanges(string query)
    {
        // Arrange
        const string expected = "http://localhost/path?param=value";
        var uri = new Uri(expected, UriKind.Absolute);

        // Act
        var actual = uri.AppendQuery(query);

        // Assert
        Assert.AreEqual(expected, actual.AbsoluteUri);
    }

    [TestCase("http://localhost", "", "http://localhost/")]
    [TestCase("http://localhost", "/", "http://localhost/?/")]
    [TestCase("http://localhost", "?query=value", "http://localhost/?query=value")]
    [TestCase("http://localhost", "query", "http://localhost/?query")]
    [TestCase("http://localhost", "query=value", "http://localhost/?query=value")]
    [TestCase("http://localhost/path", "", "http://localhost/path")]
    [TestCase("http://localhost/path", "/", "http://localhost/path?/")]
    [TestCase("http://localhost/path", "?query=value", "http://localhost/path?query=value")]
    [TestCase("http://localhost/path", "query", "http://localhost/path?query")]
    [TestCase("http://localhost/path", "query=value", "http://localhost/path?query=value")]
    [TestCase("http://localhost:1234", "", "http://localhost:1234/")]
    [TestCase("http://localhost:1234", "/", "http://localhost:1234/?/")]
    [TestCase("http://localhost:1234", "?query=value", "http://localhost:1234/?query=value")]
    [TestCase("http://localhost:1234", "query", "http://localhost:1234/?query")]
    [TestCase("http://localhost:1234", "query=value", "http://localhost:1234/?query=value")]
    public static void AppendQuery_QueryValid_ShouldReturnWithQuery(
        string uriString,
        string query,
        string expected)
    {
        // Arrange
        var uri = new Uri(uriString, UriKind.Absolute);

        // Act
        var actual = uri.AppendQuery(query);

        // Assert
        Assert.AreEqual(expected, actual.AbsoluteUri);
    }

    [Test]
    public static void AppendQuery_UriNull_ShouldThrow()
    {
        // Arrange
        Uri? nullUri = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => nullUri!.AppendQuery(string.Empty));
    }
}

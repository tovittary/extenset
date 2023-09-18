namespace Extenset.Tests;

[TestFixture]
internal sealed partial class UriExtensionsTests
{
    [TestCase("http://localhost", "", "http://localhost/")]
    [TestCase("http://localhost", "/path#fragment=value", "http://localhost/path#fragment=value")]
    [TestCase("http://localhost", "path#fragment", "http://localhost/path#fragment")]
    [TestCase("http://localhost/path", "", "http://localhost/path")]
    [TestCase("http://localhost/path", "/path#fragment=value", "http://localhost/path/path#fragment=value")]
    [TestCase("http://localhost/path", "path#fragment", "http://localhost/path/path#fragment")]
    [TestCase("http://localhost:1234", "", "http://localhost:1234/")]
    [TestCase("http://localhost:1234", "/path#fragment=value", "http://localhost:1234/path#fragment=value")]
    [TestCase("http://localhost:1234", "path#fragment", "http://localhost:1234/path#fragment")]
    public static void AppendPathWithFragment_PathWithFragment_ShouldReturnWithPathWithFragment(
        string uriString,
        string pathWithFragment,
        string expected)
    {
        // Arrange
        var uri = new Uri(uriString, UriKind.Absolute);

        // Act
        var actual = uri.AppendPathWithFragment(pathWithFragment);

        // Assert
        Assert.AreEqual(expected, actual.AbsoluteUri);
    }

    [TestCase("")]
    [TestCase(null)]
    public static void AppendPathWithFragment_PathWithFragmentNullOrEmpty_ShouldReturnWithoutChanges(
        string pathWithFragment)
    {
        // Arrange
        const string expected = "http://localhost/path#fragment";
        var uri = new Uri(expected, UriKind.Absolute);

        // Act
        var actual = uri.AppendPathWithFragment(pathWithFragment);

        // Assert
        Assert.AreEqual(expected, actual.AbsoluteUri);
    }

    [Test]
    public static void AppendPathWithFragment_UriNull_ShouldThrow()
    {
        // Arrange
        Uri? nullUri = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => nullUri!.AppendPathWithFragment(string.Empty));
    }
}

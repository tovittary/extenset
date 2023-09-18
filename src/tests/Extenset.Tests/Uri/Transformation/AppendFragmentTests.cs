namespace Extenset.Tests;

[TestFixture]
internal sealed partial class UriExtensionsTests
{
    [TestCase(
        "http://localhost/#fragment",
        "&additional",
        "http://localhost/#fragment&additional")]
    [TestCase(
        "http://localhost/path#fragment",
        "&additional",
        "http://localhost/path#fragment&additional")]
    [TestCase(
        "http://localhost/path?query=test#fragment",
        "&additional",
        "http://localhost/path?query=test#fragment&additional")]
    public static void AppendFragment_AlreadyHasFragment_ShouldCombineFragments(
        string uriString,
        string fragment,
        string expected)
    {
        // Arrange
        var uri = new Uri(uriString, UriKind.Absolute);

        // Act
        var actual = uri.AppendFragment(fragment);

        // Assert
        Assert.AreEqual(expected, actual.AbsoluteUri);
    }

    [TestCase("")]
    [TestCase(null)]
    public static void AppendFragment_FragmentNullOrEmpty_ShouldReturnWithoutChanges(string fragment)
    {
        // Arrange
        const string expected = "http://localhost/path";
        var uri = new Uri(expected, UriKind.Absolute);

        // Act
        var actual = uri.AppendFragment(fragment);

        // Assert
        Assert.AreEqual(expected, actual.AbsoluteUri);
    }

    [TestCase("http://localhost", "", "http://localhost/")]
    [TestCase("http://localhost", "/", "http://localhost/#/")]
    [TestCase("http://localhost", "#fragment", "http://localhost/#fragment")]
    [TestCase("http://localhost", "fragment", "http://localhost/#fragment")]
    [TestCase("http://localhost", "fragment=value", "http://localhost/#fragment=value")]
    [TestCase("http://localhost/path", "", "http://localhost/path")]
    [TestCase("http://localhost/path", "/", "http://localhost/path#/")]
    [TestCase("http://localhost/path", "#fragment", "http://localhost/path#fragment")]
    [TestCase("http://localhost/path", "fragment", "http://localhost/path#fragment")]
    [TestCase("http://localhost/path", "fragment=value", "http://localhost/path#fragment=value")]
    [TestCase("http://localhost:1234", "", "http://localhost:1234/")]
    [TestCase("http://localhost:1234", "/", "http://localhost:1234/#/")]
    [TestCase("http://localhost:1234", "#fragment", "http://localhost:1234/#fragment")]
    [TestCase("http://localhost:1234", "fragment", "http://localhost:1234/#fragment")]
    [TestCase("http://localhost:1234", "fragment=value", "http://localhost:1234/#fragment=value")]
    public static void AppendFragment_FragmentValid_ShouldReturnWithFragment(
        string uriString,
        string fragment,
        string expected)
    {
        // Arrange
        var uri = new Uri(uriString, UriKind.Absolute);

        // Act
        var actual = uri.AppendFragment(fragment);

        // Assert
        Assert.AreEqual(expected, actual.AbsoluteUri);
    }

    [Test]
    public static void AppendFragment_UriNull_ShouldThrow()
    {
        // Arrange
        Uri? nullUri = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => nullUri!.AppendFragment(string.Empty));
    }
}

namespace Extenset.Tests;

using System.Text;
using System.Xml;

[TestFixture]
internal sealed partial class XmlWriterExtensionsTests
{
    [TestCase("")]
    [TestCase(null)]
    public static void WriteStartElementAsync_NameNullOrEmpty_ShouldThrow(string name)
    {
        // Arrange
        using var stream = new MemoryStream();
        using var writer = XmlWriter.Create(stream);

        // Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => writer.WriteStartElementAsync(name));
    }

    [Test]
    public static async Task WriteStartElementAsync_NameValid_ShouldWriteElement()
    {
        // Arrange
        const string elementName = "Element";
        const string expected = "<Element />";

        using var stream = new MemoryStream();
        using var writer = XmlWriter.Create(
            stream,
            new XmlWriterSettings { Encoding = Encoding.ASCII, Async = true, OmitXmlDeclaration = true });

        // Act
        await writer.WriteStartDocumentAsync();
        await writer.WriteStartElementAsync(elementName);
        await writer.WriteEndElementAsync();
        await writer.WriteEndDocumentAsync();
        await writer.FlushAsync();

        var actualBytes = stream.ToArray();
        var actual = Encoding.ASCII.GetString(actualBytes);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public static void WriteStartElementAsync_WriterNull_ShouldThrow()
    {
        // Arrange
        const string elementName = "Element";
        XmlWriter? nullWriter = null;

        // Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => nullWriter!.WriteStartElementAsync(elementName));
    }
}

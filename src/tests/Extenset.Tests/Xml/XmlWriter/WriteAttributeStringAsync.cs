namespace Extenset.Tests;

using System.Text;
using System.Xml;

[TestFixture]
internal sealed partial class XmlWriterExtensionsTests
{
    [TestCase("")]
    [TestCase(null)]
    public static void WriteAttributeStringAsync_NameNullOrEmpty_ShouldThrow(string name)
    {
        // Arrange
        using var stream = new MemoryStream();
        using var writer = XmlWriter.Create(stream);

        // Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => writer.WriteAttributeStringAsync(name, string.Empty));
    }

    [Test]
    public static async Task WriteAttributeStringAsync_NameAndValueValid_ShouldWriteAttribute()
    {
        // Arrange
        const string elementName = "Element";
        const string attributeName = "attributeName";
        const string attributeValue = "attributeValue";
        const string expected = "<Element attributeName=\"attributeValue\" />";

        using var stream = new MemoryStream();
        using var writer = XmlWriter.Create(
            stream,
            new XmlWriterSettings { Encoding = Encoding.ASCII, Async = true, OmitXmlDeclaration = true });

        // Act
        await writer.WriteStartDocumentAsync();
        await writer.WriteStartElementAsync(elementName);
        await writer.WriteAttributeStringAsync(attributeName, attributeValue);
        await writer.WriteEndElementAsync();
        await writer.WriteEndDocumentAsync();
        await writer.FlushAsync();

        var actualBytes = stream.ToArray();
        var actual = Encoding.ASCII.GetString(actualBytes);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public static void WriteAttributeStringAsync_ValueNull_ShouldThrow()
    {
        // Arrange
        const string attributeName = "attributeName";

        using var stream = new MemoryStream();
        using var writer = XmlWriter.Create(stream);

        // Assert
        Assert.ThrowsAsync<ArgumentNullException>(() =>
            writer.WriteAttributeStringAsync(attributeName, null!));
    }

    [Test]
    public static void WriteAttributeStringAsync_WriterNull_ShouldThrow()
    {
        // Arrange
        const string elementName = "Element";
        XmlWriter? nullWriter = null;

        // Assert
        Assert.ThrowsAsync<ArgumentNullException>(() =>
            nullWriter!.WriteAttributeStringAsync(elementName, string.Empty));
    }
}

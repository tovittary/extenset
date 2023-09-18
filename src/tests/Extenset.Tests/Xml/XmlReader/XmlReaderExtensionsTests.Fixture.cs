namespace Extenset.Tests;

internal sealed partial class XmlReaderExtensionsTests
{
    private const string XmlDocumentString =
        """
        <Document>
            <FirstElement />
            <SecondElement />
        </Document>
        """;

    private const string XmlDocumentWithBoolString =
        """
        <Document>
            <Element attributeName="true" />
        </Document>
        """;

    private const string XmlDocumentWithSubtreeString =
        """
        <Document>
            <Subtree>
                <Element attributeName="true" />
            </Subtree>
        </Document>
        """;
}

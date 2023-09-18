namespace Extenset;

using System.Xml;

/// <summary>
/// Extension methods for <see cref="XmlReader" />.
/// </summary>
public static partial class XmlReaderExtensions
{
    /// <summary>
    /// Asynchronously creates and returns a new <see cref="XmlReader" /> instance that can be used
    /// to read the current node, and all its descendants.
    /// </summary>
    /// <param name="reader">The <see cref="XmlReader" /> instance.</param>
    /// <returns>
    /// A new XML reader instance set to the node that was current before the call
    /// to the <see cref="ReadSubtreeAsync" /> method.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="reader" /> is <c>null</c>.</exception>
    public static async Task<XmlReader> ReadSubtreeAsync(this XmlReader reader)
    {
        if (reader is null) throw new ArgumentNullException(nameof(reader));

        var subtreeReader = reader.ReadSubtree();
        await subtreeReader.ReadAsync().ConfigureAwait(false);

        return subtreeReader;
    }
}

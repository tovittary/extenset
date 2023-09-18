namespace Extenset;

using System.Xml;

/// <summary>
/// Extension methods for <see cref="XmlWriter" />.
/// </summary>
public static partial class XmlWriterExtensions
{
    /// <summary>
    /// Asynchronously writes the specified start tag without any associations with namespace or prefix.
    /// </summary>
    /// <param name="writer">The <see cref="XmlWriter" /> instance.</param>
    /// <param name="name">The qualified name of the element.</param>
    /// <returns>
    /// The <see cref="Task" /> that represents the asynchronous start tag write operation.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="writer" /> or <paramref name="name" /> is <c>null</c> or empty.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// <see cref="XmlWriter.WriteStartElementAsync" />.
    /// </exception>
    public static Task WriteStartElementAsync(this XmlWriter writer, string name)
    {
        if (writer is null) throw new ArgumentNullException(nameof(writer));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

        return writer.WriteStartElementAsync(string.Empty, name, string.Empty);
    }
}

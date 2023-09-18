namespace Extenset;

using System.Xml;

/// <summary>
/// Extension methods for <see cref="XmlReader" />.
/// </summary>
public static partial class XmlReaderExtensions
{
    /// <summary>
    /// Asynchronously advances the reader to the next element.
    /// </summary>
    /// <param name="reader">The <see cref="XmlReader" /> instance.</param>
    /// <returns>
    /// <c>true</c> if the next element is reached successfully; otherwise <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="reader" /> is <c>null</c>.</exception>
    public static async Task<bool> ReadToFollowingAsync(this XmlReader reader)
    {
        if (reader is null) throw new ArgumentNullException(nameof(reader));

        var readSuccess = await reader.ReadAsync().ConfigureAwait(false);
        while (readSuccess)
        {
            var isElement = reader.NodeType == XmlNodeType.Element;
            if (isElement)
                return true;

            readSuccess = await reader.ReadAsync().ConfigureAwait(false);
        }

        return false;
    }

    /// <summary>
    /// Asynchronously reads until an element with the specified qualified name is found.
    /// </summary>
    /// <param name="reader">The <see cref="XmlReader" /> instance.</param>
    /// <param name="name">The qualified name of the element.</param>
    /// <returns>
    /// <c>true</c> if the element with the specified name is found; otherwise <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="reader" /> or <paramref name="name" /> is <c>null</c> or empty.
    /// </exception>
    public static async Task<bool> ReadToFollowingAsync(this XmlReader reader, string name)
    {
        if (reader is null) throw new ArgumentNullException(nameof(reader));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

        var nextElementRead = await ReadToFollowingAsync(reader).ConfigureAwait(false);
        while (nextElementRead)
        {
            var elementFound = reader.Name.Equals(name, StringComparison.InvariantCulture);
            if (elementFound)
                return true;

            nextElementRead = await ReadToFollowingAsync(reader).ConfigureAwait(false);
        }

        return false;
    }
}

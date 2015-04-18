using System.Globalization;
using System.Text;
using Newtonsoft.Json.Schema;

namespace SharpChunker.Json
{
    public interface IJsonChunkerSettings : IChunkerSettings
    {
        /// <summary>
        /// Determines the size of the buffer for the reader.
        /// </summary>
        int BufferSize { get; }

        /// <summary>
        /// Schema used to validate the JSON. If this is null, the JSON will not be
        /// validated upon.
        /// </summary>
        JsonSchema ValidationSchema { get; }

        /// <summary>
        /// Encoding used to read the input.
        /// </summary>
        Encoding InputEncoding { get; }

        /// <summary>
        /// Culture used while reading the JSON file.
        /// </summary>
        CultureInfo CultureInfo { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;

namespace SharpChunker.Json
{
    public class JsonChunkerSettings : IJsonChunkerSettings
    {
        /// <summary>
        /// Determines if the chunker should include invalid entities when it's counting the number of entities read.
        /// </summary>
        /// <remarks>
        /// If this is set to false, and you request 500 entities, the chunker will read until it reaches 500 
        /// valid entities. Otherwise, the chunker will read the first 500 entities, even if none of them are valid.
        /// 
        /// Default value is true.
        /// </remarks>
        public bool IncludeInvalidEntitiesInCount { get; set; }

        /// <summary>
        /// Determines if the Input Stream should be closed at the same time the <see cref="IChunkReader"/> is closed.
        /// </summary>
        /// <remarks>
        /// Default value is false.
        /// </remarks>
        public bool CloseInputStream { get; set; }

        /// <summary>
        /// Determines the size of the buffer for the reader.
        /// </summary>
        /// <remarks>Default is 4096</remarks>
        public int BufferSize { get; set; }

        /// <summary>
        /// Schema used to validate the JSON. If this is null, the JSON will not be
        /// validated upon.
        /// </summary>
        /// <remarks>
        /// Default value is null.
        /// </remarks>
        public JsonSchema ValidationSchema { get; set; }

        /// <summary>
        /// Encoding used to read the input.
        /// </summary>
        /// <remarks>
        /// Default value is UTF-8.
        /// </remarks>
        public Encoding InputEncoding { get; set; }

        /// <summary>
        /// Culture used while reading the JSON file.
        /// </summary>
        /// <remarks>
        /// Default is InvariantCulture.
        /// </remarks>
        public CultureInfo CultureInfo { get; set; }

        public JsonChunkerSettings()
        {
            IncludeInvalidEntitiesInCount = true;
            CloseInputStream = false;
            BufferSize = 4096;
            ValidationSchema = null;
            InputEncoding = Encoding.UTF8;
            CultureInfo = CultureInfo.InvariantCulture;
        }
    }
}

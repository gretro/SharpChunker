using System;

namespace SharpChunker
{
    /// <summary>
    /// Interface for any chunker.
    /// </summary>
    public interface IChunkReader : IDisposable
    {
        /// <summary>
        /// Determines the end of the stream has been reached.
        /// </summary>
        bool EndOfStreamReached { get; }

        /// <summary>
        /// Opens the chunk reader and prepares it for its first read.
        /// </summary>
        void Open();

        /// <summary>
        /// Closes the chunk reader.
        /// </summary>
        void Close();
    }
}

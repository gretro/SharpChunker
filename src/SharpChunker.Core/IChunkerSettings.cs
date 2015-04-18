namespace SharpChunker
{
    public interface IChunkerSettings
    {
        /// <summary>
        /// Determines if the chunker should include invalid entities when it's counting the number of entities read.
        /// </summary>
        /// <remarks>
        /// If this is set to false, and you request 500 entities, the chunker will read until it reaches 500 
        /// valid entities. Otherwise, the chunker will read the first 500 entities, even if none of them are valid.
        /// </remarks>
        bool IncludeInvalidEntitiesInCount { get; }

        /// <summary>
        /// Determines if the Input Stream should be closed at the same time the <see cref="IChunkReader"/> is closed.
        /// </summary>
        bool CloseInputStream { get; }
    }
}

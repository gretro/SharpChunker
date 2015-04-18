using System.Threading.Tasks;

namespace SharpChunker
{
    public interface IAsyncChunkReader : IChunkReader
    {
        /// <summary>
        /// Opens asynchronously the chunk reader and prepares it for its first read.
        /// </summary>
        /// <returns></returns>
        Task OpenAsync();
    }
}

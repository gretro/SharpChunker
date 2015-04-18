using System.Collections.Generic;

namespace SharpChunker.Models
{
    public class Chunk<T>
    {


        public IEnumerable<T> Entities { get; set; }
    }
}

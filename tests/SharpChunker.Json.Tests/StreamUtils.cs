using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SharpChunker.Json.Tests.TestDataModel;

namespace SharpChunker.Json.Tests
{
    public static class StreamUtils
    {
        private const int NumberOfBooks = 100;
        private static List<Book> _data;

        static StreamUtils()
        {
            _data = new List<Book>();

            for (int i = 0; i < NumberOfBooks; i++)
            {
                var book = new Book()
                {
                    Id = i,
                    Name = "Book #" + i
                };

                _data.Add(book);
            }
        }

        public static Stream GenerateArrayStream(Encoding encoding)
        {
            var stream = new MemoryStream();

            using (var streamWriter = new StreamWriter(stream, encoding, 4096, true))
            {
                using (var jsonWriter = new JsonTextWriter(streamWriter) { CloseOutput = false })
                {
                    jsonWriter.WriteStartArray();

                    foreach (var book in _data)
                    {
                        jsonWriter.WriteStartObject();

                        jsonWriter.WritePropertyName("id", true);
                        jsonWriter.WriteValue(book.Id);

                        jsonWriter.WritePropertyName("name", true);
                        jsonWriter.WriteValue(book.Name);

                        jsonWriter.WriteEndObject();
                    }

                    jsonWriter.WriteEndArray();
                }   
            }

            stream.Position = 0;
            return stream;
        }

        public static Stream GenerateObjectStream(Encoding encoding)
        {
            var stream = new MemoryStream();

            using (var streamWriter = new StreamWriter(stream, encoding, 4096, true))
            {
                using (var jsonWriter = new JsonTextWriter(streamWriter) { CloseOutput = false })
                {
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("data");
                    jsonWriter.WriteStartArray();

                    foreach (var book in _data)
                    {
                        jsonWriter.WriteStartObject();

                        jsonWriter.WritePropertyName("id", true);
                        jsonWriter.WriteValue(book.Id);

                        jsonWriter.WritePropertyName("name", true);
                        jsonWriter.WriteValue(book.Name);

                        jsonWriter.WriteEndObject();
                    }

                    jsonWriter.WriteEndArray();
                    jsonWriter.WriteEndObject();
                }
            }

            stream.Position = 0;
            return stream;
        }
    }
}

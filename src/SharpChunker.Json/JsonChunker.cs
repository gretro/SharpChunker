using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharpChunker.Json
{
    public class JsonChunker : IChunkReader
    {
        private StreamReader _streamReader;
        private JsonReader _jsonReader;
        private JsonValidatingReader _jsonValidatingReader;

        public bool EndOfStreamReached
        {
            get
            {
                if (_streamReader == null) { throw new InvalidOperationException("Please make sure the JsonChunker is opened in order to invoke this property.");}
                return _streamReader.EndOfStream;
            }
        }

        /// <summary>
        /// Settings for the <see cref="JsonChunker"/>.
        /// </summary>
        public IJsonChunkerSettings Settings { get; private set; }

        /// <summary>
        /// Underlying stream used by the <see cref="JsonChunker"/>.
        /// </summary>
        public Stream JsonStream { get; private set; }

        /// <summary>
        /// Gets the token the reader is actually reading.
        /// </summary>
        public JsonToken CurrentToken
        {
            get
            {
                var reader = GetReader();
                if (reader == null) { throw new InvalidOperationException("Please make sure the JsonChunker is opened.");}

                return reader.TokenType;
            }
        }

        public JsonChunker(Stream jsonStream)
            :this(jsonStream, new JsonChunkerSettings())
        {
            
        }

        public JsonChunker(Stream jsonStream, IJsonChunkerSettings settings)
        {
            if (jsonStream == null) throw new ArgumentNullException("jsonStream");
            if (settings == null) throw new ArgumentNullException("settings");

            Settings = settings;
            JsonStream = jsonStream;
        }

        public void Open()
        {
            CreateJsonReaderForStream();
            PrepareCursor();
        }

        private void CreateJsonReaderForStream()
        {
            _streamReader = new StreamReader(JsonStream, Settings.InputEncoding, true, Settings.BufferSize, !Settings.CloseInputStream);
            _jsonReader = new JsonTextReader(_streamReader)
                {
                    CloseInput = Settings.CloseInputStream,
                    Culture = Settings.CultureInfo
                };

            if (Settings.ValidationSchema != null)
            {
                _jsonValidatingReader = new JsonValidatingReader(_jsonReader)
                {
                    CloseInput = Settings.CloseInputStream, 
                    Schema = Settings.ValidationSchema,
                    Culture = Settings.CultureInfo,
                };   
            }
        }

        private void PrepareCursor()
        {
            var jsonReader = GetReader();

            MoveCursorToFirstArray(jsonReader);
            MoveCursorToFirstObjectInArray(jsonReader);
        }

        private void MoveCursorToFirstArray(JsonReader jsonReader)
        {
            while (jsonReader.TokenType != JsonToken.StartArray && !EndOfStreamReached)
            {
                jsonReader.Read();
            }
        }

        private void MoveCursorToFirstObjectInArray(JsonReader jsonReader)
        {
            while (jsonReader.TokenType != JsonToken.StartObject 
                && !EndOfStreamReached 
                && jsonReader.TokenType != JsonToken.EndArray)
            {
                jsonReader.Read();
            }
        }


        private JsonReader GetReader()
        {
            if (_jsonValidatingReader != null)
            {
                return _jsonValidatingReader;
            }

            return _jsonReader;
        }

        public void Close()
        {
            Dispose();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

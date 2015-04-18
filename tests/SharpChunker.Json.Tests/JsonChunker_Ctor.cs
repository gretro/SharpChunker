using System;
using System.IO;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace SharpChunker.Json.Tests
{
    [TestFixture]
    public class JsonChunker_Ctor
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WHEN_jsonStream_null_SHOULD_throw_ArgumentNullException()
        {
            //Arrange
            Stream stream = null;

            //Act
            var chunker = new JsonChunker(stream);
        }

        [Test]
        public void WHEN_jsonStream_is_ok_SHOULD_settings_be_defined()
        {
            //Arrange
            Stream stream = StreamUtils.GenerateArrayStream(Encoding.UTF8);

            //Act
            var chunker = new JsonChunker(stream);
            var settings = chunker.Settings;

            //Assert
            settings.Should().NotBeNull();
        }

         
    }
}

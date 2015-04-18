namespace SharpChunker.Models
{
    public class LogError
    {
        /// <summary>
        /// Determines the line number at which the error was detected.
        /// </summary>
        public long? LinePosition { get; set; }

        /// <summary>
        /// Determines the char position in the line where the error was detected.
        /// </summary>
        public long? CharPosition { get; set; }

        /// <summary>
        /// Message logged for this error.
        /// </summary>
        public string Message { get; set; }
    }
}

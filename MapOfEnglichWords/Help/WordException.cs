using System;
using System.Runtime.Serialization;

namespace MapOfEnglishWords.Help
{
    [Serializable]
    public class WordException : Exception
    {
        public WordException()
        {
        }

        public WordException(string message) : base(message)
        {
        }

        public WordException(string message, Exception inner) : base(message, inner)
        {
        }

        protected WordException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}

using System;
using System.Runtime.Serialization;

namespace MarsRover.Core.Abstraction.Exceptions
{
    public class CoreLayerException : Exception
    {
        public CoreLayerException()
        {
        }

        public CoreLayerException(string message) : base(message)
        {
        }

        public CoreLayerException(string message, Exception exception) : base(message, exception)
        {
        }

        public CoreLayerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

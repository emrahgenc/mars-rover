using System;
using System.Runtime.Serialization;

namespace MarsRover.Core.Abstraction.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException()
        {
        }

        public BusinessException(string message) : base(message)
        {
        }

        public BusinessException(string message, Exception exception) : base(message, exception)
        {
        }

        public BusinessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
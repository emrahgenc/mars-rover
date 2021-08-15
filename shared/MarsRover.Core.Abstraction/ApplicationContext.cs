using MarsRover.Core.Abstraction.Exceptions;

namespace MarsRover.Core.Abstraction
{
    public static class ApplicationContext
    {
        public static void ThrowBusinessException(string message)
        {
            throw new BusinessException(message);
        }

    }
}

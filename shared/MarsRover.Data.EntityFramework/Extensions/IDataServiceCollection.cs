using Microsoft.Extensions.DependencyInjection;

namespace MarsRover.Data.EntityFramework.Extensions
{
    public interface IDataServiceCollection
    {
        IServiceCollection ServiceCollection { get; }
    }
}
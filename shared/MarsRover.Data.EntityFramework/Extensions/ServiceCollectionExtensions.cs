using MarsRover.Core.Abstraction.Data;
using MarsRover.Data.EntityFramework.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRover.Data.EntityFramework.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IDataServiceCollection AddDataContext<TDbContext>(this IServiceCollection serviceCollection,
            Action<DbContextOptionsBuilder> optionsAction = null) where TDbContext : DbContext
        {
            serviceCollection.AddDbContextPool<TDbContext>(optionsAction);
            serviceCollection.AddScoped<DbContext>(provider => provider.GetService<TDbContext>());

            return new DataServiceCollection(serviceCollection);
        }

        public static IDataServiceCollection AddEntityFrameworkData(this IDataServiceCollection dataServiceCollection)
        {
            var services = dataServiceCollection.ServiceCollection;

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IQuery<>), typeof(Query<>));

            return dataServiceCollection;
        }
    }
}

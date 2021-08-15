using MarsRover.Core.Abstraction.Domain.SeedWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Core.Abstraction.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IAggregateRoot;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        int SaveChanges(bool acceptAllChangesOnSuccess);
        bool BeginNewTransaction();
        bool RollBackTransaction();
        Task<TEntity> AttachAsync<TEntity>(object id) where TEntity : class;
    }
}

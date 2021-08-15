using System.Threading;
using Ardalis.GuardClauses;
using MarsRover.Core.Abstraction.Data;
using MarsRover.Core.Abstraction.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MarsRover.Data.EntityFramework.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        private readonly DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetSingleAsync(object id, CancellationToken cancellationToken = default)
        {
            return await Entities.FindAsync(new [] {id}, cancellationToken);
        }


        public async Task MarkForInsertionAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            Guard.Against.Null(entity, nameof(entity));

            await Entities.AddAsync(entity, cancellationToken);
        }

        public async Task MarkForDeletion(object id, CancellationToken cancellationToken = default)
        {
            var entity = await GetSingleAsync(id,cancellationToken);

            Guard.Against.Null(entity, nameof(entity));

            MarkForDeletion(entity);
        }

        public void MarkForDeletion(TEntity entity)
        {
            Guard.Against.Null(entity, nameof(entity));

            Entities.Remove(entity);
        }

        private DbSet<TEntity> Entities => _context.Set<TEntity>();
    }
}
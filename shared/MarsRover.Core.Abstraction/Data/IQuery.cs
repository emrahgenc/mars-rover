using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Core.Abstraction.Data
{
    public interface IQuery<TEntity>
    {
        Task<TEntity> SingleOrDefaultAsync(CancellationToken cancellationToken = default);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetAllAsync(
            CancellationToken cancellationToken = default);
    }
}

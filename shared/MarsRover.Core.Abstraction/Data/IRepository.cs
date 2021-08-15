using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Core.Abstraction.Data
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetSingleAsync(object id, CancellationToken cancellationToken = default);
        Task MarkForInsertionAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task MarkForDeletion(object id, CancellationToken cancellationToken = default);
        void MarkForDeletion(TEntity entity);
    }
}
using MarsRover.Core.Abstraction.Data;
using MarsRover.Data.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Data.EntityFramework.DataAccess
{
    public class Query<TEntity> : IQuery<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly IQueryable<TEntity> entities;

        public Query(DbContext context)
        {
            _context = context;
            entities = _context.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> SingleOrDefaultAsync(CancellationToken cancellationToken = default)
        {
            return await entities.SingleOrDefaultAsync(cancellationToken);
        }
        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await entities.SingleOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await entities.AnyAsync(predicate, cancellationToken);
        }

        public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await entities.Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await entities.ToListAsync(cancellationToken);
        }
    }
}

using Hospi.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Hopsi.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly HospiDbContext _db;
        protected readonly DbSet<T> _dbSet;

        public Repository(HospiDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public async Task<T> AddAsync(T entity, CancellationToken token)
        {
            await _dbSet.AddAsync(entity, token);
            await SaveAsync(token);
            return entity;
        }

        public async Task DeleteAsync(T entity, CancellationToken token)
        {
            _dbSet.Remove(entity);
            await SaveAsync(token);
        }

        public async Task<IReadOnlyCollection<T>> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken token)
        {
            return await _dbSet.Where(predicate).ToListAsync(token);
        }

        public async Task<T> GetByIdAsync(Guid id, CancellationToken token)
        {
            var entity = await _dbSet.SingleOrDefaultAsync(e => e.Id == id, token);

            return entity;
        }

        public async Task SaveAsync(CancellationToken token)
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity, CancellationToken token)
        {
            _dbSet.Update(entity);
            await SaveAsync(token);
        }
    }
}

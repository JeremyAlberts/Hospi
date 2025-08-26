using System.Linq.Expressions;

namespace Hospi.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id, CancellationToken token);
        Task<IReadOnlyCollection<T>> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken token);
        Task<T> AddAsync(T entity, CancellationToken token);
        Task UpdateAsync(T entity, CancellationToken token);
        Task DeleteAsync(T entity, CancellationToken token);
        Task SaveAsync(CancellationToken token);
    }
}



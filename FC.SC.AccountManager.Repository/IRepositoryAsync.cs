using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FC.SC.AccountManager.Repository
{
    public interface IRepositoryAsync<T> : IRepository<T>
        where T : class
    {
        Task<IEnumerable<T>> GetAsync(Func<T, bool> predicate = null, CancellationToken cancellationToken = default);

        Task<T> GetOneAsync(Func<T, bool> predicate = null, CancellationToken cancellationToken = default);

        Task<IEnumerable<T>> GetAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);

        Task<T> GetOneAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);

        Task<T> FindAsync(object[] keyValues, CancellationToken cancellationToken = default);

        Task AddAsync(T entity, CancellationToken cancellationToken = default);

        Task AddAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

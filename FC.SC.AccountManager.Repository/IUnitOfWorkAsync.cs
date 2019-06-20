using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FC.SC.AccountManager.Repository
{
    public interface IUnitOfWorkAsync : IUnitOfWork
    {
        Task<IEnumerable<T>> GetAsync<T>(Func<T, bool> predicate = null, CancellationToken cancellationToken = default)
            where T : class;

        Task<T> GetOneAsync<T>(Func<T, bool> predicate = null, CancellationToken cancellationToken = default)
            where T : class;

        Task<IEnumerable<T>> GetAsync<T>(ISpecification<T> spec, CancellationToken cancellationToken = default)
            where T : class;

        Task<T> GetOneAsync<T>(ISpecification<T> spec, CancellationToken cancellationToken = default)
            where T : class;

        Task<T> FindAsync<T>(object[] keyValues, CancellationToken cancellationToken = default)
            where T : class;

        Task AddAsync<T>(T entity, CancellationToken cancellationToken = default)
            where T : class;

        Task AddAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default)
            where T : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

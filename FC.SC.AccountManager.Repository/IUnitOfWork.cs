using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FC.SC.AccountManager.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }

        IEnumerable<T> Get<T>(Func<T, bool> predicate = null)
            where T : class;

        T GetOne<T>(Func<T, bool> predicate = null)
            where T : class;

        IEnumerable<T> Get<T>(ISpecification<T> spec)
            where T : class;

        T GetOne<T>(ISpecification<T> spec)
            where T : class;

        T Find<T>(params object[] keyValues)
            where T : class;

        T Add<T>(T entity)
            where T : class;

        void Add<T>(IEnumerable<T> entities)
            where T : class;

        T Update<T>(T entity)
            where T : class;

        void Update<T>(IEnumerable<T> entities)
            where T : class;

        void Remove<T>(T entity)
            where T : class;

        void Remove<T>(IEnumerable<T> entities)
            where T : class;

        int SaveChanges();

        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}

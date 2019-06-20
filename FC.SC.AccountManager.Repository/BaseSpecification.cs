using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FC.SC.AccountManager.Repository
{
    public abstract class BaseSpecification<T> : ISpecification<T>
        where T : class
    {
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } =
            new List<Expression<Func<T, object>>>();

        public List<string> IncludeStrings { get; } =
            new List<string>();

        protected BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }
    }
}

using Entity.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Entity.Repositories
{
    public class BaseRepository
    {
        public abstract class RepositoryBase<T> : IBaseRepository<T> where T : class
        {
            protected RepositoryContext RepositoryContext { get; set; }

            public RepositoryBase(RepositoryContext repositoryContext)
            {
                RepositoryContext = repositoryContext;
            }

            public IQueryable<T> FindAll()
            {
                return RepositoryContext.Set<T>().AsNoTracking();
            }

            public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
            {
                return RepositoryContext.Set<T>().Where(expression);
            }

            public void Create(T entity)
            {
                RepositoryContext.Set<T>().Add(entity);
            }

            public void Update(T entity)
            {
                RepositoryContext.Set<T>().Update(entity);
            }

            public void Delete(T entity)
            {
                RepositoryContext.Set<T>().Remove(entity);
            }
        }
    }
}

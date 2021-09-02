using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

using Domain.Interfaces;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }

        public GenericRepository(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public T Get(int id)
        {
            return RepositoryContext.Set<T>().Find(id);
        }

        public async Task<T> GetAsync(int id)
        {
            return await RepositoryContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> Get()
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        //public async Task<IQueryable<T>> GetAsync()
        //{
        //    throw new NotImplementedException();
        //    //return await RepositoryContext.Set<T>().AllAsync<T>;
        //}

        //public async Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> expression)
        //{
        //    return await RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        //}

        public void Add(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
        }

        public void Remove(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }
    }
}
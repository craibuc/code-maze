using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGenericRepository<T>
    {
        T Get(int id);
        Task<T> GetAsync(int id);
        
        IQueryable<T> Get();
        //Task<IQueryable<T>> GetAsync();
        
        IQueryable<T> Find(Expression<Func<T, bool>> expression);
        //Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> expression);

        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}

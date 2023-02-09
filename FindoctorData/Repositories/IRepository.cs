using System.Linq.Expressions;

namespace FindoctorData.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        Task AddAsync(T entity);
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        //Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByGuidAsync(Guid id);
        //Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        //Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        //Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
    }
}

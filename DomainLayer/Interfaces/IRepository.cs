using System.Linq.Expressions;

namespace DomainLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAllIncludes(params Expression<Func<T, Object>>[] includes);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
        void RemoveRangeAsync(IEnumerable<T> entities);
        void CreateRangeAsync(IEnumerable<T> entities);


    }
}
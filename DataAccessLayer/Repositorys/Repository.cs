using DataAccessLayer.DataContext;
using DomainLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositorys
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationContext db;
        private readonly DbSet<T> dbSet;

        public Repository(ApplicationContext _db)
        {
            db = _db;
            dbSet = db.Set<T>();
        }
    
        public async Task<T> CreateAsync(T entity)
        {
            return (await dbSet.AddAsync(entity)).Entity;
        }

        public void CreateRangeAsync(IEnumerable<T> entities)
        {
            dbSet.AddRangeAsync(entities);
        }
        public async Task<bool> DeleteAsync(T entity)
        {
            var result= await Task.FromResult( dbSet.Remove(entity));
            return result is not null ? true : false;
        }
        public IEnumerable<T> GetAllIncludes(params Expression<Func<T, Object>>[] includes)
        {
            var entities = dbSet.AsQueryable();
            foreach (var include in includes)
            {
                return entities.Include(include);
            }
            return entities.ToList();
        }
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await dbSet.Where(expression).ToListAsync();

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public void RemoveRangeAsync(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            dbSet.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            return entity;
           /* var result = await Task.FromResult(_DbSet.Update(TEntity));
            return result is not null ? true : false;*/
        }
      
    }
}

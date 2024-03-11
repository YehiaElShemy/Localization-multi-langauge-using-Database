using DataAccessLayer.DataContext;
using DomainLayer.Interfaces;

namespace DataAccessLayer.Repositorys
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationContext db { get; set; }
        public IRepositoryProject project { get; set; }
        public UnitOfWork(ApplicationContext _db)
        {
            db = _db;
            project=new ProjectRepository(db);  
        }
        public void Dispose()
        {
            db.Dispose();
        }
        public async Task<int> SaveChangeAsync()
        {
          return await db.SaveChangesAsync();
        }
    }
}

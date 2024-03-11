using DataAccessLayer.DataContext;
using DomainLayer.Entities;
using DomainLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositorys
{
    public class ProjectRepository : Repository<Projects>, IRepositoryProject
    {
        public ProjectRepository(ApplicationContext db):base(db)
        {
        }
        public async Task<IEnumerable<Projects>> GetPopularProjects(int count)
        {
            return db.Set<Projects>().Take(count).ToList();    
        }
    }
}

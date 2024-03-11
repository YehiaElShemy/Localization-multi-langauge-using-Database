using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DataContext
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            
        }
    }
}

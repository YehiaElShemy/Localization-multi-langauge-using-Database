using Microsoft.EntityFrameworkCore;
using whatssappnotificaion.Models.localize;

namespace whatssappnotificaion.Models.DataContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> option):base(option)
        {
            
        }
        public DbSet<Language> languages { get; set; }
        public DbSet<StringResource> stringResources { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StringResource>().HasIndex(x => new { x.key, x.LangaugeId }).IsUnique();
            base.OnModelCreating(modelBuilder);
        }

    }
}

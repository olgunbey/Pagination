using Microsoft.EntityFrameworkCore;

namespace LazyLoading.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptionsBuilder):base(dbContextOptionsBuilder)
        {
            
        }
        DbSet<Urunler> Urunsler { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
        }
    }
}

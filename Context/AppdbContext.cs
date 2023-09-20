using AngularNew.Module;
using Microsoft.EntityFrameworkCore;

namespace AngularNew.Context
{
    public class AppdbContext :DbContext 
    {
        public AppdbContext(DbContextOptions<AppdbContext> options):base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");

        }
    }
}

using Microsoft.EntityFrameworkCore;
using ITWEB_Mandatory5.Models;

namespace ITWEB_Mandatory5.DAL
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Models.Component> Components { get; set; }
        public DbSet<ComponentType> ComponentTypes { get; set; }
        public DbSet<ESImage> EsImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Models.Component>().ToTable("Components");
            modelBuilder.Entity<ComponentType>().ToTable("ComponentTypes");
            modelBuilder.Entity<ESImage>().ToTable("ESImages");
        }
    }
}

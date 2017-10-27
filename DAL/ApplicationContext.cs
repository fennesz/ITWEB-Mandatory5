using ITWEB_Mandatory5.Models;
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
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Component>().ToTable("Components");
            modelBuilder.Entity<ComponentType>().ToTable("ComponentTypes");
            modelBuilder.Entity<ESImage>().ToTable("ESImages");

            modelBuilder.Entity<ComponentTypeCategory>()
                .HasKey(cc => new { cc.ComponentTypeId, cc.CategoryId });

            modelBuilder.Entity<ComponentTypeCategory>()
                .HasOne(cc => cc.Category)
                .WithMany(c => c.ComponentTypeCategory)
                .HasForeignKey(cc => cc.CategoryId);

            modelBuilder.Entity<ComponentTypeCategory>()
                .HasOne(cc => cc.ComponentType)
                .WithMany(c => c.ComponentTypeCategories)
                .HasForeignKey(cc => cc.ComponentTypeId);

            modelBuilder.Entity<ComponentType>()
                .HasMany(c => c.Components)
                .WithOne(e => e.ComponentType)
                .HasForeignKey(k => k.ComponentTypeId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

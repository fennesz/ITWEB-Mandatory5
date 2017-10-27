using ITWEB_Mandatory5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWEB_Mandatory5.DAL
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
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

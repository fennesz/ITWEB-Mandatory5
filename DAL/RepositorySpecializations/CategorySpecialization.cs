using ITWEB_Mandatory5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWEB_Mandatory5.DAL
{
    public class CategoryRepository : IRepository<Category>
    {

        protected readonly ApplicationContext context;
        protected DbSet<Category> entities;
        string errorMessage = string.Empty;

        public CategoryRepository(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<Category>();
        }

        public IEnumerable<Category> GetAll()
        {
            return entities
                .Include(x => x.ComponentTypeCategory)
                .ThenInclude(x => x.ComponentType)
                .AsEnumerable();
        }

        public Category Get(long id)
        {
            return entities
                .Include(x => x.ComponentTypeCategory)
                .ThenInclude(x => x.ComponentType)
                .SingleOrDefault(s => s.Id == id);
        }

        public void Insert(Category entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var insertedEntity = entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(Category entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }

        public void Delete(Category entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<Category> Find(Func<Category, bool> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException("entity");
            }
            return entities
                .Include(x => x.ComponentTypeCategory)
                .ThenInclude(x => x.ComponentType)
                .Where(predicate);
        }
    }
}

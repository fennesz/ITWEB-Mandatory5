using ITWEB_Mandatory5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWEB_Mandatory5.DAL
{
    public class ComponentTypeRepository : IRepository<ComponentType>
    {

        protected readonly ApplicationContext context;
        protected DbSet<ComponentType> entities;
        string errorMessage = string.Empty;

        public ComponentTypeRepository(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<ComponentType>();
        }

        public IEnumerable<ComponentType> GetAll()
        {
            return entities
                .Include(x => x.ComponentTypeCategory)
                .ThenInclude(x => x.Category)
                .AsEnumerable();
        }

        public ComponentType Get(long id)
        {
            return entities
                .Include(x => x.ComponentTypeCategory)
                .ThenInclude(x => x.Category)
                .SingleOrDefault(s => s.Id == id);
        }

        public void Insert(ComponentType entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var insertedEntity = entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(ComponentType entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }

        public void Delete(ComponentType entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<ComponentType> Find(Func<ComponentType, bool> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException("entity");
            }
            return entities
                .Include(x => x.ComponentTypeCategory)
                .ThenInclude(x => x.Category)
                .Where(predicate);
        }
    }
}

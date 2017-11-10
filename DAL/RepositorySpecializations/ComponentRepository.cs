using ITWEB_Mandatory5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWEB_Mandatory5.DAL
{
    public class ComponentRepository : IRepository<Component>
    {

        protected readonly ApplicationContext context;
        protected DbSet<Component> entities;
        string errorMessage = string.Empty;

        public ComponentRepository(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<Component>();
        }

        public IEnumerable<Component> GetAll()
        {
            return entities
                .Include(x => x.ComponentType)
                .AsEnumerable();
        }

        public Component Get(long id)
        {
            return entities
                .Include(x => x.ComponentType)
                .SingleOrDefault(s => s.Id == id);
        }

        public void Insert(Component entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var insertedEntity = entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(Component entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }

        public void Delete(Component entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<Component> Find(Func<Component, bool> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException("entity");
            }
            return entities
                .Include(x => x.ComponentType)
                .Where(predicate);
        }
    }
}

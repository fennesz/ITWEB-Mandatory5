using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITWEB_Mandatory5.Library;

namespace ITWEB_Mandatory5.DAL
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext context;
        private readonly ITime _time;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(ApplicationContext context, ITime time)
        {
            this.context = context;
            _time = time;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T Get(long id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.AddedDate = _time.Get();
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<T> Find(Func<T,bool> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException("entity");
            }
            return entities.Where(predicate);
        }

    }
}

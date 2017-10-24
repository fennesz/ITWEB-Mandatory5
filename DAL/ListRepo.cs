using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWEB_Mandatory5.DAL
{
    public class ListRepository<T> : IRepository<T> where T : BaseEntity
    {
        private List<T> _data;

        public ListRepository(params T[] entities)
        {
            _data = new List<T>(entities);
        }
        public IEnumerable<T> GetAll()
        {
            return _data.AsEnumerable();
        }

        public T Get(long id)
        {
            return _data.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _data.Add(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var index = _data.FindIndex(e => entity.Id == e.Id);
            _data[index] = entity;
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _data.Remove(entity);
        }

        public IEnumerable<T> Find(Func<T,bool> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException("entity");
            }
            return _data.Where(predicate);
        }

    }
}

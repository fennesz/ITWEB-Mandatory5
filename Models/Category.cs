using ITWEB_Mandatory5.DAL;
using System.Collections.Generic;

namespace ITWEB_Mandatory5.Models
{
    public class Category : BaseEntity
    {
        public Category()
        {
            ComponentTypes = new List<ComponentType>();
        }
        public string Name { get; set; }
        public ICollection<ComponentType> ComponentTypes { get; protected set; }
    }
}
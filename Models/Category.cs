using System.Collections.Generic;

namespace ITWEB_Mandatory5.Models
{
    public class Category
    {
        public Category()
        {
            ComponentTypes = new List<ComponentType>();
        }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<ComponentType> ComponentTypes { get; protected set; }
    }
}
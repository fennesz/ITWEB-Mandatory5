using ITWEB_Mandatory5.DAL;
using System.Collections.Generic;

namespace ITWEB_Mandatory5.Models
{
    public class Category : BaseEntity
    {
        public Category()
        {
            ComponentTypeCategory = new List<ComponentTypeCategory>();
        }
        public string Name { get; set; }
        public ICollection<ComponentTypeCategory> ComponentTypeCategory { get; protected set; }
    }
}
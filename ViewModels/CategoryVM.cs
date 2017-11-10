using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITWEB_Mandatory5.Models;

namespace ITWEB_Mandatory5.ViewModels
{
    public class CategoryVM
    {
        public CategoryVM()
        {
            ComponentTypes = new List<ComponentTypeVM>();
        }
        public Int64 Id { get; set; }

        public string Name { get; set; }
        public ICollection<ComponentTypeVM> ComponentTypes { get; protected set; }
    }
}

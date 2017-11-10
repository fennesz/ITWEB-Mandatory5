using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITWEB_Mandatory5.Models;

namespace ITWEB_Mandatory5.ViewModels
{
    public class ComponentTypeVM
    {
        public ComponentTypeVM()
        {
            Components = new List<ComponentVM>();
            Categories = new List<CategoryVM>();
        }

        public Int64 Id { get; set; }

        public string ComponentName { get; set; }
        public string ComponentInfo { get; set; }
        public string Location { get; set; }
        public ComponentTypeStatus Status { get; set; }
        public string Datasheet { get; set; }
        public string ImageUrl { get; set; }
        public string Manufacturer { get; set; }
        public string WikiLink { get; set; }
        public string AdminComment { get; set; }
        public virtual ESImage Image { get; set; }
        
        public ICollection<ComponentVM> Components { get; set; }
        public ICollection<CategoryVM> Categories{ get; set; }
    }
}

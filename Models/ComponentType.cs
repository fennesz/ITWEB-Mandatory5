using ITWEB_Mandatory5.DAL;
using ITWEB_Mandatory5.Model;
using ITWEB_Mandatory5.Models;
using System.Collections.Generic;

namespace ITWEB_Mandatory5.Models
{
    public class ComponentType : BaseEntity
    {
        public ComponentType()
        {
            Components = new List<Component>();
            Categories = new List<Category>();
        }
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
        public ICollection<Component> Components { get; protected set; }
        public ICollection<Category> Categories { get; protected set; }
    }
}
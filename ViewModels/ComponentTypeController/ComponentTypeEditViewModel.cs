using ITWEB_Mandatory5.Models;
using System.Collections.Generic;

namespace ITWEB_Mandatory5.ViewModels.ComponentTypeController
{
    public class ComponentTypeEditViewmodel
    {
        
        public ComponentTypeEditViewmodel()
        {
            Components = new List<Component>();
            ComponentTypeCategory = new List<ComponentTypeCategory>();

            
        }

        public int Id {get; set;}
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
        

        // SKal de her relationships med i viewmodel?

        // many-one
        public ICollection<Component> Components { get; protected set; }
        // many-many
        public ICollection<ComponentTypeCategory> ComponentTypeCategory { get; protected set; }
    }

    // Many-Many junction class
    public class ComponentTypeCategory
    {
        public long ComponentTypeId { get; set; }
        public ComponentType ComponentType { get; set; }

        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITWEB_Mandatory5.Models;

namespace ITWEB_Mandatory5.ViewModels
{
    public class ComponentTypeCreateVM : ComponentTypeVM
    {
        public ComponentTypeCreateVM() : base()
        {
            CategoryIDs = new List<Int64>();
        }

        public IEnumerable<Int64> CategoryIDs { get; set; }
    }
}

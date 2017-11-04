using ITWEB_Mandatory5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWEB_Mandatory5.ViewModels.ComponentTypeController
{
    public class ComponentTypeIndexViewmodel
    {
        public IEnumerable<ComponentTypeDetailsViewmodel> ComponentTypes { get; set; }
    }
}

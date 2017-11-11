using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITWEB_Mandatory5.Models;

namespace ITWEB_Mandatory5.ViewModels
{
    public class ComponentVM
    {
        public Int64 Id { get; set; }

        public Int64 ComponentTypeId { get; set; }
        public ComponentTypeVM ComponentType { get; set; }

        public int ComponentNumber { get; set; }
        public string SerialNo { get; set; }
        public ComponentStatus Status { get; set; }
        public string AdminComment { get; set; }
        public string UserComment { get; set; }
    }
}

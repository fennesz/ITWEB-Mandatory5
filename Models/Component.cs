using ITWEB_Mandatory5.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWEB_Mandatory5.Models
{
    public class Component : BaseEntity
    {
        public long? ComponentTypeId { get; set; }
        public ComponentType ComponentType { get; set; }

        public int ComponentNumber { get; set; }
        public string SerialNo { get; set; }
        public ComponentStatus Status { get; set; }
        public string AdminComment { get; set; }
        public string UserComment { get; set; }
    }

}

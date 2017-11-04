using ITWEB_Mandatory5.Models;
using System.Collections.Generic;

namespace ITWEB_Mandatory5.ViewModels.ComponentController
{
    public class ComponentEditViewmodel
    {
        public int Id { get; set; }
        public long? ComponentTypeId { get; set; }
        public ComponentType ComponentType { get; set; }

        public int ComponentNumber { get; set; }
        public string SerialNo { get; set; }
        public ComponentStatus Status { get; set; }
        public string AdminComment { get; set; }
        public string UserComment { get; set; }
        //public long? CurrentLoanInformationId { get; set; }
    }
}
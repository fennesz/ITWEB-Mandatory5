using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWEB_Mandatory5.Models
{
    public enum ComponentStatus
    {
        Available,
        ReservedLoaner,
        ReservedAdmin,
        Loaned,
        Defect,
        Trashed,
        Lost,
        NeverReturned
    }
}

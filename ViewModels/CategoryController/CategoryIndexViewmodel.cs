using ITWEB_Mandatory5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWEB_Mandatory5.ViewModels.CategoryController
{
    public class CategoryIndexViewmodel
    {
        public IEnumerable<CategoryDetailsViewmodel> Categories { get; set; }
    }
}

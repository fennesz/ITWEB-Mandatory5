﻿using ITWEB_Mandatory5.Models;
using System.Collections.Generic;

namespace ITWEB_Mandatory5.ViewModels.CategoryController
{
    public class CategoryEditViewmodel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ComponentType> ComponentTypes { get; protected set; }
    }
}
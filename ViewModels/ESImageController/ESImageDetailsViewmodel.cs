using ITWEB_Mandatory5.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITWEB_Mandatory5.ViewModels.ESImageController
{
    public class ESImageDetailsViewmodel
    {    
        public int Id {get; set;}
        
        [MaxLength(128)]
        public string ImageMimeType { get; set; }
        public byte[] Thumbnail { get; set; }
        public byte[] ImageData { get; set; }
    }
}
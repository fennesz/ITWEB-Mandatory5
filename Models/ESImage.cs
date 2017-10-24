using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWEB_Mandatory5.Models
{
public class ESImage
{
    public long ESImageId { get; set; }
    [MaxLength(128)]
    public string ImageMimeType { get; set; }
    public byte[] Thumbnail { get; set; }
    public byte[] ImageData { get; set; }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Warehousely.Models
{
    public class ImageFile
    {
        [Key]
        public int Id { get; set; }
        public string ContentDisposition { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public long Length { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
    }
}

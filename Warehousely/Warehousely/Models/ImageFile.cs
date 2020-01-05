using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.DAL;

namespace Warehousely.Models
{
    public class ImageFile : BaseEntity
    {
        [Key]
        public int ImageFileId { get; set; }
        public string ContentDisposition { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public long Length { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
    }
}

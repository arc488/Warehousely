using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;

namespace Warehousely.DAL
{
    public interface IImageFileRepository
    {
        int CreateImage(IFormFile file);
        ImageFile GetById(int id);
        void DeleteImageFile(ImageFile imageFile);
    }
}

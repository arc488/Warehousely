using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;

namespace Warehousely.DAL
{
    public class ImageFileRepository : IImageFileRepository
    {
        private readonly AppDbContext _appDbContext;

        public ImageFileRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int CreateImage(IFormFile file)
        {
            var ImageFile = new ImageFile
            {
                ContentDisposition = file.ContentDisposition,
                ContentType = file.ContentType,
                FileName = file.FileName,
                Length = file.Length,
                Name = file.FileName
            };

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var imageData = ms.ToArray();
                ImageFile.Content = imageData;
            }

            _appDbContext.ImageFiles.Add(ImageFile);
            _appDbContext.SaveChanges();

            return ImageFile.Id;
        }

        public void DeleteImageFile(ImageFile imageFile)
        {
            _appDbContext.ImageFiles.Remove(imageFile);
            _appDbContext.SaveChanges();

        }

        public ImageFile GetById(int id)
        {
            return _appDbContext.ImageFiles.FirstOrDefault<ImageFile>(i => i.Id == id);
        }
    }
}

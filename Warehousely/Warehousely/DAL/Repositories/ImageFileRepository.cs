using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.DAL.IRepositories;
using Warehousely.DAL.Repositories;
using Warehousely.Models;

namespace Warehousely.DAL
{
    public class ImageFileRepository : Repository<ImageFile>, IImageFileRepository
    {
        public ImageFileRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

    }
}

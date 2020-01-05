using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;

namespace Warehousely.DAL
{
    public class SizeRepository : ISizeRepository
    {
        private readonly AppDbContext _appDbContext;

        public SizeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Size> AllSizes => _appDbContext.Sizes;

        public Size GetById(int id)
        {
            var size = _appDbContext.Sizes.FirstOrDefault<Size>(s => s.SizeId == id);
            return size;
        }
    }
}

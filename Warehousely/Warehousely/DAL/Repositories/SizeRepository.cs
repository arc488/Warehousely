using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.DAL.IRepositories;
using Warehousely.DAL.Repositories;
using Warehousely.Models;

namespace Warehousely.DAL
{
    public class SizeRepository : Repository<Size>, ISizeRepository
    {
        public SizeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}

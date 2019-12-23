using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.Models;

namespace Warehousely.DAL
{
    public interface ISizeRepository
    {
        IEnumerable<Size> AllSizes { get; }
        Size GetById(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Warehousely.DAL.IRepositories;
using Warehousely.DAL.Repositories;
using Warehousely.Models;

namespace Warehousely.Controllers.Helpers
{
    public class DbHelpers<TEntry> where TEntry : class
    {

        //public IEnumerable<TEntry> AddToMany(IEnumerable<TEntry> items, IEnumerable<object> complements, string setProp, string valueProp)
        //{
        //    foreach (var item in items)
        //    {
        //        var propToSet = item.GetType().GetProperty(setProp);
        //        var valueToSet = complements.ToList().
        //    }

        //    return items;
        //}
    }
}

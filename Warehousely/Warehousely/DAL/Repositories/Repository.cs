using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Warehousely.DAL.IRepositories;

namespace Warehousely.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly AppDbContext _appDbContext;
        protected readonly DbSet<TEntity> _entities; 

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _entities = _appDbContext.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _entities.Add(entity);
            _appDbContext.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            _entities.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _entities;
        }

        public virtual TEntity GetById(int id)
        {
            return _entities.Find(id);
        }

        public virtual void Update(TEntity entity)
        {
            _entities.Update(entity);
            _appDbContext.SaveChanges();
        }
    }
}

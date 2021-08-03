using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZbW.ITB1821H.OrderManager.Model.Context;

namespace ZbW.ITB1821H.OrderManager.Model.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        public readonly DatabaseContext _context;

        public RepositoryBase(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public long Count(Func<TEntity, bool> filter)
        {
            return _context.Set<TEntity>().Where(filter).Count();
        }

        public long Count()
        {
            return _context.Set<TEntity>().Count();
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public List<TEntity> GetAll(Func<TEntity, bool> filter)
        {
            return _context.Set<TEntity>().Where(filter).ToList();
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetSingle(int pkValue)
        {
            return _context.Set<TEntity>().Find(pkValue);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }
    }
}

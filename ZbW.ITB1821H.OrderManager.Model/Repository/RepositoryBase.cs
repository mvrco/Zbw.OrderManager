using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ZbW.ITB1821H.OrderManager.Model.Context;
using ZbW.ITB1821H.OrderManager.Model.Repository.Interfaces;

namespace ZbW.ITB1821H.OrderManager.Model.Repository
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        public void Add(TEntity entity)
        {
            using (var context = new DatabaseContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        public long Count(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<TEntity>().Where(filter).Count();
            }
        }

        public long Count()
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<TEntity>().Count();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var  context = new DatabaseContext())
            {
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public List<TEntity> GetAll()
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public TEntity GetSingle(int pkValue)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<TEntity>().Find(pkValue);
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new DatabaseContext())
            {
                context.Set<TEntity>().Update(entity);
                context.SaveChanges();
            }
        }
    }
}

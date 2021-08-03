using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ZbW.ITB1821H.OrderManager.Model.Context;
using ZbW.ITB1821H.OrderManager.Model.Repository;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        public readonly DbContextOptionsBuilder _contextOptions;

        public ServiceBase() : this(new DbContextOptionsBuilder().UseSqlServer(Properties.Settings.Default.ConnectionString)) { }

        public ServiceBase(DbContextOptionsBuilder options) { _contextOptions = options; }

        public void Add(TEntity entity)
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                new RepositoryBase<TEntity>(context).Add(entity);
            }
        }

        public long Count(Func<TEntity, bool> filter)
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                return new RepositoryBase<TEntity>(context).Count(filter);
            }
        }

        public long Count()
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                return new RepositoryBase<TEntity>(context).Count();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                new RepositoryBase<TEntity>(context).Delete(entity);
            }
        }

        public List<TEntity> GetAll(Func<TEntity, bool> filter)
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                return new RepositoryBase<TEntity>(context).GetAll(filter);
            }
        }

        public List<TEntity> GetAll()
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                return new RepositoryBase<TEntity>(context).GetAll();
            }
        }

        public TEntity GetSingle(int pkValue)
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                return new RepositoryBase<TEntity>(context).GetSingle(pkValue);
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                new RepositoryBase<TEntity>(context).Update(entity);
            }
        }
    }
}

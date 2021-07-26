using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ZbW.ITB1821H.OrderManager.Model.Repository;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        public readonly DbContextOptionsBuilder _contextOptions;
        public IRepositoryBase<TEntity> _repository;

        public ServiceBase() 
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            _contextOptions = optionsBuilder.UseSqlServer(Properties.Settings.Default.ConnectionString);
        }

        public ServiceBase(DbContextOptionsBuilder options)
        {
            _contextOptions = options;
        }

        public void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public long Count(Func<TEntity, bool> filter)
        {
            return _repository.Count(filter);
        }

        public long Count()
        {
            return _repository.Count();
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public List<TEntity> GetAll(Func<TEntity, bool> filter)
        {
            return _repository.GetAll(filter);
        }

        public List<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetSingle(int pkValue)
        {
            return _repository.GetSingle(pkValue);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }
    }
}

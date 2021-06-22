using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.ITB1821H.OrderManager.Model.Repository
{
    public interface IRepositoryBase<TEntity>
    {
        TEntity GetSingle(int pkValue);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        List<TEntity> GetAll(Func<TEntity, bool> filter);
        List<TEntity> GetAll();
        long Count(Func<TEntity, bool> filter);
        long Count();
    }
}

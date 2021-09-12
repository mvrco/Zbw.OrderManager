using System.Collections.Generic;

namespace ZbW.ITB1821H.OrderManager.Model.Repository.Interfaces
{
    public interface IReportingRepositoryBase<TEntity>
    {
        List<TEntity> Get();
    }
}

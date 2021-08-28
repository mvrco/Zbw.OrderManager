using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.ITB1821H.OrderManager.Model.Repository
{
    public interface IReportingRepositoryBase<TEntity>
    {
        List<TEntity> Get();
    }
}

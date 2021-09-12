using System.Collections.Generic;

namespace ZbW.ITB1821H.OrderManager.Model.Service.Interfaces
{
    public interface IReportingServiceBase<TEntity, TEntityDto>
    {
        List<TEntityDto> Get();
    }
}

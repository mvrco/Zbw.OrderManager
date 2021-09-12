using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ZbW.ITB1821H.OrderManager.Model.Service.Interfaces
{
  public interface IServiceBase<TEntity, TEntityDto>
  {
    TEntityDto GetSingle(int pkValue);
    void Add(TEntityDto entity);
    void Delete(TEntityDto entity);
    void Update(TEntityDto entity);
    List<TEntityDto> GetAll(Expression<Func<TEntityDto, bool>> filter);
    List<TEntityDto> GetAll();
    long Count(Expression<Func<TEntityDto, bool>> filter);
    long Count();
  }
}

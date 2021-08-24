using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ZbW.ITB1821H.OrderManager.Model.Repository;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
    public abstract class ServiceBase<TEntity, TEntityDto> : IServiceBase<TEntity, TEntityDto>
        where TEntity : class
        where TEntityDto : class
    {
        public IMapper _mapper;
        public IRepositoryBase<TEntity> _repo;

        public ServiceBase(IRepositoryBase<TEntity> repo)
        {
            _repo = repo;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TEntity, TEntityDto>().ReverseMap();
                cfg.AddExpressionMapping();
            });
            _mapper = new Mapper(config);
        }

        public void Add(TEntityDto entity)
        {
            _repo.Add(_mapper.Map<TEntity>(entity));
        }

        public long Count(Expression<Func<TEntityDto, bool>> filter)
        {
            return _repo.Count(_mapper.Map<Expression<Func<TEntity, bool>>>(filter));
        }

        public long Count()
        {
            return _repo.Count();
        }

        public void Delete(TEntityDto entity)
        {
            _repo.Delete(_mapper.Map<TEntity>(entity));
        }

        public List<TEntityDto> GetAll(Expression<Func<TEntityDto, bool>> filter)
        {
            var result = _repo.GetAll(_mapper.Map<Expression<Func<TEntity, bool>>>(filter));
            return _mapper.Map<List<TEntityDto>>(result);
        }

        public List<TEntityDto> GetAll()
        {
            var result = _repo.GetAll();
            return _mapper.Map<List<TEntityDto>>(result);
        }

        public TEntityDto GetSingle(int pkValue)
        {
            var result = _repo.GetSingle(pkValue);
            return _mapper.Map<TEntityDto>(result);
        }

        public void Update(TEntityDto entity)
        {
            _repo.Update(_mapper.Map<TEntity>(entity));
        }
    }
}

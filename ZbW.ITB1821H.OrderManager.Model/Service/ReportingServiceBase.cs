using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using ZbW.ITB1821H.OrderManager.Model.Repository.Interfaces;
using ZbW.ITB1821H.OrderManager.Model.Service.Interfaces;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
    public abstract class ReportingServiceBase<TEntity, TEntityDto> : IReportingServiceBase<TEntity, TEntityDto>
        where TEntity : class
        where TEntityDto : class
    {
        public IMapper _mapper;
        public IReportingRepositoryBase<TEntity> _repo;

        protected ReportingServiceBase(IReportingRepositoryBase<TEntity> repo)
        {
            _repo = repo;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TEntity, TEntityDto>().ReverseMap();
                cfg.AddExpressionMapping();
            });
            _mapper = new Mapper(config);
        }

        public List<TEntityDto> Get()
        {
            var result = _repo.Get();
            return _mapper.Map<List<TEntityDto>>(result);
        }
    }
}

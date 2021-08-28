using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using ZbW.ITB1821H.OrderManager.Model.Repository;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
    public abstract class ReportinServiceBase<TEntity, TEntityDto> : IReportingServiceBase<TEntity, TEntityDto>
        where TEntity : class
        where TEntityDto : class
    {
        public IMapper _mapper;
        public IReportingRepositoryBase<TEntity> _repo;

        public ReportinServiceBase(IReportingRepositoryBase<TEntity> repo)
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

using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using System;
using ZbW.ITB1821H.OrderManager.Model.Dto;
using ZbW.ITB1821H.OrderManager.Model.Entities;
using ZbW.ITB1821H.OrderManager.Model.Repository.Interfaces;
using ZbW.ITB1821H.OrderManager.Model.Service.Interfaces;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
    public class PositionService : ServiceBase<Position, PositionDto>, IPositionService
    {
        public PositionService(IPositionRepository repo) : base(repo)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Position, PositionDto>().ReverseMap();
                cfg.CreateMap<Order, OrderDto>().ReverseMap();
                cfg.CreateMap<Article, ArticleDto>().ReverseMap();
                cfg.CreateMap<ArticleGroup, ArticleGroupDto>().ReverseMap();
                cfg.AddExpressionMapping();
            });
            _mapper = new Mapper(config);
        }

        public new void Delete(PositionDto entity)
        {
            throw new InvalidOperationException("The position depends to an order and therefore cannot be deleted.");
        }
    }
}

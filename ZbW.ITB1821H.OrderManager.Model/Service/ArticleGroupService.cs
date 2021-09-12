using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using System;
using ZbW.ITB1821H.OrderManager.Model.Dto;
using ZbW.ITB1821H.OrderManager.Model.Entities;
using ZbW.ITB1821H.OrderManager.Model.Repository.Interfaces;
using ZbW.ITB1821H.OrderManager.Model.Service.Interfaces;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
    public class ArticleGroupService : ServiceBase<ArticleGroup, ArticleGroupDto>, IArticleGroupService
    {
        public ArticleGroupService(IArticleGroupRepository repo) : base(repo)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArticleGroup, ArticleGroupDto>().ReverseMap();
                cfg.CreateMap<Article, ArticleDto>().ReverseMap();
                cfg.CreateMap<Position, PositionDto>().ReverseMap();
                cfg.CreateMap<Order, OrderDto>().ReverseMap();
                cfg.AddExpressionMapping();
            });
            _mapper = new Mapper(config);
        }

        public new void Delete(ArticleGroupDto entity)
        {
            if (entity.SubArticleGroups.Count == 0 && entity.Articles.Count == 0)
            {
                _repo.Delete(_mapper.Map<ArticleGroup>(entity));
            }
            else
            {
                throw new InvalidOperationException("The articelgroup depends to other entities and therefore cannot be deleted.");
            }
        }
    }
}

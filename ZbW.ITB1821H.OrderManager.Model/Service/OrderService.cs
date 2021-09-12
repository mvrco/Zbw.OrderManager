using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using ZbW.ITB1821H.OrderManager.Model.Dto;
using ZbW.ITB1821H.OrderManager.Model.Entities;
using ZbW.ITB1821H.OrderManager.Model.Repository.Interfaces;
using ZbW.ITB1821H.OrderManager.Model.Service.Interfaces;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
    public class OrderService : ServiceBase<Order, OrderDto>, IOrderService
    {
        public OrderService(IOrderRepository repo) : base(repo)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDto>().ReverseMap();
                cfg.CreateMap<Customer, CustomerDto>().ReverseMap();
                cfg.CreateMap<Position, PositionDto>().ReverseMap();
                cfg.CreateMap<Article, ArticleDto>().ReverseMap();
                cfg.CreateMap<Address, AddressDto>().ReverseMap();
                cfg.AddExpressionMapping();
            });
            _mapper = new Mapper(config);
        }
    }
}

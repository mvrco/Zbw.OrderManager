using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using ZbW.ITB1821H.OrderManager.Model.Dto;
using ZbW.ITB1821H.OrderManager.Model.Entities;
using ZbW.ITB1821H.OrderManager.Model.Repository.Interfaces;
using ZbW.ITB1821H.OrderManager.Model.Service.Interfaces;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
    public class CustomerService : ServiceBase<Customer, CustomerDto>, ICustomerService
    {
        public CustomerService(ICustomerRepository repo) : base(repo)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDto>().ReverseMap();
                cfg.CreateMap<Address, AddressDto>().ReverseMap();
                cfg.CreateMap<Order, OrderDto>().ReverseMap();
                cfg.CreateMap<Position, PositionDto>().ReverseMap();
                cfg.AddExpressionMapping();
            });
            _mapper = new Mapper(config);
        }
    }
}

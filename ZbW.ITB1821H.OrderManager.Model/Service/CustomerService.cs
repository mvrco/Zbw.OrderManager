using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using System;
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

        public new void Delete(CustomerDto entity)
        {
            if (entity.Orders == null)
            {
                _repo.Delete(_mapper.Map<Customer>(entity));
            }
            else
            {
                throw new InvalidOperationException("This customer already has invoices and can therefore no longer be deleted.");
            }
        }
    }
}

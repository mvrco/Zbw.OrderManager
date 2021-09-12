using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using System;
using ZbW.ITB1821H.OrderManager.Model.Dto;
using ZbW.ITB1821H.OrderManager.Model.Entities;
using ZbW.ITB1821H.OrderManager.Model.Repository.Interfaces;
using ZbW.ITB1821H.OrderManager.Model.Service.Interfaces;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
    public class AddressService : ServiceBase<Address, AddressDto>, IAddressService
    {
        public AddressService(IAddressRepository repo) : base(repo)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Address, AddressDto>().ReverseMap();
                cfg.CreateMap<Customer, CustomerDto>().ReverseMap();
                cfg.CreateMap<Order, OrderDto>().ReverseMap();
                cfg.CreateMap<Position, PositionDto>().ReverseMap();
                cfg.AddExpressionMapping();
            });
            _mapper = new Mapper(config);
        }

        public new void Delete(AddressDto entity)
        {
            if (entity.Customers == null)
            {
                _repo.Delete(_mapper.Map<Address>(entity));
            }
            else
            {
                throw new InvalidOperationException("The address depends to a customer and therefore cannot be deleted.");
            }
        }
    }
}

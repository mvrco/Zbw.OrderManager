using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ZbW.ITB1821H.OrderManager.Model.Context;
using ZbW.ITB1821H.OrderManager.Model.Repository;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
    public class AddressService : ServiceBase<Address>
    {
        public AddressService() : base() { _repository = new AddressRepository(new DatabaseContext(_contextOptions)); }
        public AddressService(DbContextOptionsBuilder optionsBuilder) : base(optionsBuilder) { _repository = new AddressRepository(new DatabaseContext(_contextOptions)); }
       
        public new List<Address> GetAll(Func<Address, bool> filter)
        {
            return _repository.GetAll(filter);
        }

        public new List<Address> GetAll()
        {
            return _repository.GetAll();
        }

        public new Address GetSingle(int pkValue)
        {
            return _repository.GetSingle(pkValue);
        }
    }
}

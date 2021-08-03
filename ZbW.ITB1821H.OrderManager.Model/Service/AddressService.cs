using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ZbW.ITB1821H.OrderManager.Model.Context;
using ZbW.ITB1821H.OrderManager.Model.Repository;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
    public class AddressService : ServiceBase<Address>
    {
        public AddressService() : base() { }
        public AddressService(DbContextOptionsBuilder optionsBuilder) : base(optionsBuilder) { }
       
        public new List<Address> GetAll(Func<Address, bool> filter)
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                return new AddressRepository(context).GetAll(filter);
            }
        }

        public new List<Address> GetAll()
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                return new AddressRepository(context).GetAll();
            }
        }

        public new Address GetSingle(int pkValue)
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                return new AddressRepository(context).GetSingle(pkValue);
            }
        }
    }
}

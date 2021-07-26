using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ZbW.ITB1821H.OrderManager.Model.Context;
using ZbW.ITB1821H.OrderManager.Model.Repository;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
    public class CustomerService : ServiceBase<Customer>
    {
        public CustomerService() : base() { _repository = new CustomerRepository(new DatabaseContext(_contextOptions.Options)); }
        public CustomerService(DbContextOptionsBuilder optionsBuilder) : base(optionsBuilder) { _repository = new CustomerRepository(new DatabaseContext(_contextOptions.Options)); }

        public new List<Customer> GetAll(Func<Customer, bool> filter)
        {
            return _repository.GetAll(filter);
        }

        public new List<Customer> GetAll()
        {
            return _repository.GetAll();
        }

        public new Customer GetSingle(int pkValue)
        {
            return _repository.GetSingle(pkValue);
        }
    }
}

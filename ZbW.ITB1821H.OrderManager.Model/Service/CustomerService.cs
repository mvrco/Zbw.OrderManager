using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ZbW.ITB1821H.OrderManager.Model.Context;
using ZbW.ITB1821H.OrderManager.Model.Repository;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
    public class CustomerService : ServiceBase<Customer>
    {
        public CustomerService() : base() { }
        public CustomerService(DbContextOptionsBuilder optionsBuilder) : base(optionsBuilder) { }

        public new List<Customer> GetAll(Func<Customer, bool> filter)
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                return new CustomerRepository(context).GetAll(filter);
            }
        }

        public new List<Customer> GetAll()
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                return new CustomerRepository(context).GetAll();
            }
        }

        public new Customer GetSingle(int pkValue)
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                return new CustomerRepository(context).GetSingle(pkValue);
            }
        }
    }
}

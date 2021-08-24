using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ZbW.ITB1821H.OrderManager.Model.Context;
using ZbW.ITB1821H.OrderManager.Model.Entities;
using ZbW.ITB1821H.OrderManager.Model.Repository.Interfaces;

namespace ZbW.ITB1821H.OrderManager.Model.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository() : base() { }

        public new List<Customer> GetAll(Expression<Func<Customer, bool>> filter)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Customer>()
                    .Include(x => x.Address)
                    .Include(x => x.Orders)
                    .Where(filter)
                    .ToList();
            }
        }

        public new List<Customer> GetAll()
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Customer>()
                    .Include(x => x.Address)
                    .Include(x => x.Orders)
                    .ToList();
            }
        }

        public new Customer GetSingle(int pkValue)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Customer>()
                    .Include(x => x.Address)
                    .Include(x => x.Orders)
                    .FirstOrDefault(x => x.Id == pkValue);
            }
        }
    }
}

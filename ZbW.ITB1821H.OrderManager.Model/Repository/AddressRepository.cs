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
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository() : base() { }

        public new List<Address> GetAll(Expression<Func<Address, bool>> filter)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Address>()
                    .Include(x => x.Customers)
                    .Where(filter)
                    .ToList();
            }
        }

        public new List<Address> GetAll()
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Address>()
                .Include(x => x.Customers)
                .ToList();
            }
        }

        public new Address GetSingle(int pkValue)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Address>()
                .Include(x => x.Customers)
                .FirstOrDefault(x => x.Id == pkValue);
            }
        }
    }
}

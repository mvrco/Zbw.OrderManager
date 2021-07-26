using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZbW.ITB1821H.OrderManager.Model.Context;

namespace ZbW.ITB1821H.OrderManager.Model.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>
    {
        public CustomerRepository(DatabaseContext context) : base(context) { }

        public new List<Customer> GetAll(Func<Customer, bool> filter)
        {
            using (_context)
            {
                return _context.Set<Customer>()
                    .Include(x => x.Address)
                    .Include(x => x.Orders)
                    .Where(filter)
                    .ToList();
            }
        }

        public new List<Customer> GetAll()
        {
            return _context.Set<Customer>()
                .Include(x => x.Address)
                .Include(x => x.Orders)
                .ToList();
        }

        public new Customer GetSingle(int pkValue)
        {
            return _context.Set<Customer>()
                .Include(x => x.Address)
                .Include(x => x.Orders)
                .FirstOrDefault(x => x.Id == pkValue);
        }
    }
}

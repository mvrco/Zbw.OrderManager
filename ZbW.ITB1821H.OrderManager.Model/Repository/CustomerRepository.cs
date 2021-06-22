using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZbW.ITB1821H.OrderManager.Model.Context;

namespace ZbW.ITB1821H.OrderManager.Model.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>
    {
        public new List<Customer> GetAll(Func<Customer, bool> filter)
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

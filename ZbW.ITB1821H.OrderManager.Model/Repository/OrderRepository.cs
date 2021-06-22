using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZbW.ITB1821H.OrderManager.Model.Context;

namespace ZbW.ITB1821H.OrderManager.Model.Repository
{
    public class OrderRepository : RepositoryBase<Order>
    {
        public new List<Order> GetAll(Func<Order, bool> filter)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Order>()
                    .Include(x => x.Customer)
                    .Include(x => x.Positions)
                    .Where(filter)
                    .ToList();
            }
        }

        public new List<Order> GetAll()
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Order>()
                    .Include(x => x.Customer)
                    .Include(x => x.Positions)
                    .ToList();
            }
        }

        public new Order GetSingle(int pkValue)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Order>()
                    .Include(x => x.Customer)
                    .Include(x => x.Positions)
                    .FirstOrDefault(x => x.Id == pkValue);
            }
        }
    }
}

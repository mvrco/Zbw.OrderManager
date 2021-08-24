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
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository() : base() { }

        public new List<Order> GetAll(Expression<Func<Order, bool>> filter)
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

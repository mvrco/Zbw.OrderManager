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
                    .ThenInclude(x => x.Address)
                    .Include(x => x.Positions)
                    .ThenInclude(x => x.Article)
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
                    .ThenInclude(x => x.Address)
                    .Include(x => x.Positions)
                    .ThenInclude(x => x.Article)
                    .ToList();
            }
        }

        public new Order GetSingle(int pkValue)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Order>()
                    .Include(x => x.Customer)
                    .ThenInclude(x => x.Address)
                    .Include(x => x.Positions)
                    .ThenInclude(x => x.Article)
                    .FirstOrDefault(x => x.Id == pkValue);
            }
        }

        public void Delete(Order entity)
        {
            throw new InvalidOperationException("The order depends to positions and therefore cannot be deleted.");
        }
    }
}

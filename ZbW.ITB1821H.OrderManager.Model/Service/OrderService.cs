using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ZbW.ITB1821H.OrderManager.Model.Context;
using ZbW.ITB1821H.OrderManager.Model.Repository;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
    public class OrderService : ServiceBase<Order>
    {
        public OrderService() : base() { _repository = new OrderRepository(new DatabaseContext(_contextOptions)); }
        public OrderService(DbContextOptionsBuilder optionsBuilder) : base(optionsBuilder) { _repository = new OrderRepository(new DatabaseContext(_contextOptions)); }

        public new List<Order> GetAll(Func<Order, bool> filter)
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                return new OrderRepository(context).GetAll(filter);
            }
        }

        public new List<Order> GetAll()
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                return new OrderRepository(context).GetAll();
            }
        }

        public new Order GetSingle(int pkValue)
        {
            using (var context = new DatabaseContext(_contextOptions))
            {
                return new OrderRepository(context).GetSingle(pkValue);
            }
        }
    }
}

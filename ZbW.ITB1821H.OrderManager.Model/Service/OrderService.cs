using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ZbW.ITB1821H.OrderManager.Model.Context;
using ZbW.ITB1821H.OrderManager.Model.Repository;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
    public class OrderService : ServiceBase<Order>
    {
        public OrderService() : base() { _repository = new OrderRepository(new DatabaseContext(_contextOptions.Options)); }
        public OrderService(DbContextOptionsBuilder optionsBuilder) : base(optionsBuilder) { _repository = new OrderRepository(new DatabaseContext(_contextOptions.Options)); }

        public new List<Order> GetAll(Func<Order, bool> filter)
        {
            return _repository.GetAll(filter);
        }

        public new List<Order> GetAll()
        {
            return _repository.GetAll();
        }

        public new Order GetSingle(int pkValue)
        {
            return _repository.GetSingle(pkValue);
        }
    }
}

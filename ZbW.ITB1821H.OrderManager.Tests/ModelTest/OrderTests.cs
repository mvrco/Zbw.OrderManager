using System;
using System.Linq;
using Xunit;
using ZbW.ITB1821H.OrderManager.Model;
using ZbW.ITB1821H.OrderManager.Model.Repository;
using ZbW.ITB1821H.OrderManager.Model.Service;

namespace ZbW.ITB1821H.OrderManager.Tests.ModelTest
{
    public class OrderTests : TestingDb
    {
        #region Repository
        [Fact]
        public void OrderRepositoryAdd_AddNewOrder_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new OrderRepository(DbContext);
                var order = new Order { DateOfPurchase = new DateTime(2021, 1, 30), CustomerId = 1 };
                repo.Add(order);
                var ordersContext = DbContext.Orders.ToList();

                Assert.True(ordersContext.Contains(order) == true);
            }
        }

        [Fact]
        public void OrderRepositoryCountWithFilter_CountOrders_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new OrderRepository(DbContext);
                var ordersContext = DbContext.Orders.Where(x => x.CustomerId == 1).ToList();

                Assert.True(repo.Count(x => x.CustomerId == 1) == ordersContext.Count);
            }
        }

        [Fact]
        public void OrderRepositoryCount_CountOrders_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new OrderRepository(DbContext);

                Assert.True(repo.Count() == DbContext.Orders.Count());
            }
        }

        [Fact]
        public void OrderRepositoryDelete_DeleteOrder_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new OrderRepository(DbContext);
                var order = new Order { Id = 1234 };
                repo.Delete(order);
                var ordersContext = DbContext.Orders.ToList();

                Assert.True(!ordersContext.Contains(order) && ordersContext.Count == 18);
            }
        }

        [Fact]
        public void OrderRepositoryGetAll_GetAllOrdersWithFilter_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new OrderRepository(DbContext);
                var ordersContext = DbContext.Orders.Where(x => x.CustomerId == 1).ToList();
                var orders = repo.GetAll(x => x.CustomerId == 1);

                Assert.True(orders.Count == ordersContext.Count);
            }
        }

        [Fact]
        public void OrderRepositoryGetAll_GetAllOrders_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new OrderRepository(DbContext);
                var ordersContext = DbContext.Orders.ToList();
                var orders = repo.GetAll();

                Assert.True(orders.Count == ordersContext.Count);
            }
        }

        [Fact]
        public void OrderRepositoryGetSingle_GetSingleOrderObject_ReturnsEqual()
        {
            using (DbContext)
            {
                var repo = new OrderRepository(DbContext);
                var orderContext = DbContext.Orders.Where(x => x.Id == 1234).SingleOrDefault();
                var order = repo.GetSingle(1234);

                Assert.Equal(order, orderContext);
            }
        }

        [Fact]
        public void OrderRepositoryUpdate_UpdateOrder_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new OrderRepository(DbContext);
                var orderContext = DbContext.Orders.Where(x => x.Id == 1234).SingleOrDefault();
                orderContext.CustomerId = 5;
                repo.Update(orderContext);
                var orderContextAfterUpdate = DbContext.Orders.Where(x => x.Id == 1234).SingleOrDefault();

                Assert.True(orderContextAfterUpdate.CustomerId == 5);
            }
        }
        #endregion Repository

        #region Service
        [Fact]
        public void OrderServiceCount_CountAdressesWithFilter_ReturnsTrue()
        {
            var service = new OrderService(OptionsBuilder);
            var ordersContext = DbContext.Orders.Where(x => x.CustomerId == 1).ToList();

            Assert.True(service.Count(x => x.CustomerId == 1) == ordersContext.Count);
        }

        [Fact]
        public void OrderServiceCount_CountCustomers_ReturnsTrue()
        {
            var service = new OrderService(OptionsBuilder);

            Assert.True(service.Count() == DbContext.Orders.Count());
        }

        [Fact]
        public void OrderServiceGetAll_GetAllOrdersWithFilter_ReturnsTrue()
        {
            var service = new OrderService(OptionsBuilder);
            var ordersContext = DbContext.Orders.Where(x => x.CustomerId == 1).ToList();
            var orders = service.GetAll(x => x.CustomerId == 1);

            Assert.True(orders.Count == ordersContext.Count);
        }

        [Fact]
        public void OrderServiceGetAll_GetAllOrders_ReturnsTrue()
        {
            var service = new OrderService(OptionsBuilder);
            var ordersContext = DbContext.Orders.ToList();
            var orders = service.GetAll();

            Assert.True(orders.Count == ordersContext.Count);
        }

        [Fact]
        public void OrderServiceGetSingle_GetSingleOrder_ReturnsTrue()
        {
            var service = new OrderService(OptionsBuilder);
            var orderContext = DbContext.Orders.Where(x => x.Id == 1234).SingleOrDefault();
            var order = service.GetSingle(1234);

            Assert.True(
                order.Id == orderContext.Id
                && order.DateOfPurchase == orderContext.DateOfPurchase
                && order.CustomerId == orderContext.CustomerId);
        }
        #endregion Service
    }
}

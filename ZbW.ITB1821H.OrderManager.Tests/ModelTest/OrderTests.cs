using Moq;
using System;
using System.Linq;
using Xunit;
using ZbW.ITB1821H.OrderManager.Model.Dto;
using ZbW.ITB1821H.OrderManager.Model.Entities;
using ZbW.ITB1821H.OrderManager.Model.Repository.Interfaces;
using ZbW.ITB1821H.OrderManager.Model.Service;

namespace ZbW.ITB1821H.OrderManager.Tests.ModelTest
{
    public class OrderTests
    {
        #region Order Service/Repository
        [Fact]
        public void OrderService_Add_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IOrderRepository>();
            var order = new Order { Id = 1280, DateOfPurchase = new DateTime(2021, 2, 3), CustomerId = 3 };
            var dto = new OrderDto { Id = 1280, DateOfPurchase = new DateTime(2021, 2, 3), CustomerId = 3 };

            mock.Setup(x => x.Add(It.IsAny<Order>()))
                .Callback(() => inMemoryDatabase.Orders.Add(order));

            var service = new OrderService(mock.Object);
            service.Add(dto);

            Assert.True(inMemoryDatabase.Orders.Contains(order));
        }

        [Fact]
        public void OrderService_CountWithFilter_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IOrderRepository>();

            mock.Setup(x => x.Count(x => x.CustomerId == 1))
                .Returns(() => inMemoryDatabase.Orders.Where(x => x.CustomerId == 1).Count());

            var service = new OrderService(mock.Object);
            var count = service.Count(x => x.CustomerId == 1);

            Assert.True(count == 1);
        }

        [Fact]
        public void OrderService_Count_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IOrderRepository>();

            mock.Setup(x => x.Count())
                .Returns(() => inMemoryDatabase.Orders.Count);

            var service = new OrderService(mock.Object);
            var count = service.Count();

            Assert.True(count == 19);
        }

        [Fact]
        public void OrderService_Delete_ReturnsFalse()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IOrderRepository>();
            var order = new Order { Id = 1238, DateOfPurchase = new DateTime(2021, 2, 3), CustomerId = 3 };
            var dto = new OrderDto { Id = 1238, DateOfPurchase = new DateTime(2021, 2, 3), CustomerId = 3 };

            mock.Setup(x => x.Delete(It.IsAny<Order>()))
                .Callback(() => inMemoryDatabase.Orders.Remove(order));

            var service = new OrderService(mock.Object);
            service.Delete(dto);

            Assert.False(inMemoryDatabase.Orders.Contains(order));
        }

        [Fact]
        public void OrderService_GetAllWithFilter_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IOrderRepository>();

            mock.Setup(x => x.GetAll(x => x.CustomerId == 1))
                .Returns(() => inMemoryDatabase.Orders.Where(x => x.CustomerId == 1).ToList());

            var service = new OrderService(mock.Object);
            var list = service.GetAll(x => x.CustomerId == 1);

            Assert.True(list.Count == 1);
        }

        [Fact]
        public void OrderService_GetAll_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IOrderRepository>();

            mock.Setup(x => x.GetAll())
                .Returns(() => inMemoryDatabase.Orders.ToList());

            var service = new OrderService(mock.Object);
            var list = service.GetAll();

            Assert.True(list.Count == 19);
        }

        [Fact]
        public void OrderService_GetSingle_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IOrderRepository>();
            var dto = new OrderDto { Id = 1238, DateOfPurchase = new DateTime(2021, 2, 3), CustomerId = 3 };


            mock.Setup(x => x.GetSingle(It.IsAny<int>()))
                .Returns(() => inMemoryDatabase.Orders.Where(a => a.Id == 1238).FirstOrDefault());

            var service = new OrderService(mock.Object);
            var order = service.GetSingle(1238);

            Assert.True(
                order.Id == dto.Id
                && order.DateOfPurchase == dto.DateOfPurchase
                && order.CustomerId == dto.CustomerId);
        }

        [Fact]
        public void OrderService_Update_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IOrderRepository>();
            var order = new Order { Id = 1238, DateOfPurchase = new DateTime(2021, 2, 6), CustomerId = 3 };
            var dto = new OrderDto { Id = 1238, DateOfPurchase = new DateTime(2021, 2, 6), CustomerId = 3 };

            mock.Setup(x => x.Update(It.IsAny<Order>()))
                .Callback(() => {
                    foreach (var a in inMemoryDatabase.Orders)
                    {
                        if (a.Id == order.Id)
                        {
                            a.DateOfPurchase = order.DateOfPurchase;
                            break;
                        }
                    }
                });

            var service = new OrderService(mock.Object);
            service.Update(dto);
            var afterUpdate = inMemoryDatabase.Orders.Where(x => x.Id == order.Id).FirstOrDefault();

            Assert.True(
                order.Id == afterUpdate.Id
                && order.DateOfPurchase == afterUpdate.DateOfPurchase
                && order.CustomerId == dto.CustomerId);
        }
        #endregion
    }
}

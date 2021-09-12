using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using ZbW.ITB1821H.OrderManager.Model.Dto;
using ZbW.ITB1821H.OrderManager.Model.Entities;
using ZbW.ITB1821H.OrderManager.Model.Repository.Interfaces;
using ZbW.ITB1821H.OrderManager.Model.Service;

namespace ZbW.ITB1821H.OrderManager.Tests.ModelTest
{
    public class CustomerTests
    {
        #region Customer Service/Repository
        [Fact]
        public void CustomerService_Add_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<ICustomerRepository>();
            var dto = new CustomerDto { CustomerId = "CU10030", Name = "Monica", LastName = "Watson", Email = "watson@outlook.com", Website = "www.monica.com", Password = "45$$sDFAEeesf", AddressId = 1001 };
            var customer = new Customer { CustomerId = dto.CustomerId, Name = dto.Name, LastName = dto.LastName, Email = dto.Email, Website = dto.Website, AddressId = dto.AddressId };

            mock.Setup(x => x.Add(It.IsAny<Customer>()))
                .Callback(() => inMemoryDatabase.Customers.Add(customer));

            var service = new CustomerService(mock.Object);
            service.Add(dto);

            Assert.True(inMemoryDatabase.Customers.Contains(customer));
        }

        [Fact]
        public void CustomerService_CountWithFilter_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<ICustomerRepository>();

            mock.Setup(x => x.Count(c => c.LastName.Contains("a")))
                .Returns(() => inMemoryDatabase.Customers.Where(c => c.LastName.Contains("a")).Count());

            var service = new CustomerService(mock.Object);
            var count = service.Count(c => c.LastName.Contains("a"));

            Assert.True(count == 6);
        }

        [Fact]
        public void CustomerService_Count_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<ICustomerRepository>();

            mock.Setup(x => x.Count())
                .Returns(() => inMemoryDatabase.Customers.Count);

            var service = new CustomerService(mock.Object);
            var count = service.Count();

            Assert.True(count == 15);
        }

        [Fact]
        public void CustomerService_Delete_ReturnsFalse()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<ICustomerRepository>();
            var customer = inMemoryDatabase.Customers.Where(x => x.Id == 2).FirstOrDefault();
            var dto = new CustomerDto { Id = 2, CustomerId = "CU10002", Name = "Iris", LastName = "Watson", Email = "iris-watson@gmail.com", Website = "www.facebook.com/asdf", AddressId = 1001 };

            mock.Setup(x => x.Delete(It.IsAny<Customer>()))
                .Callback(() => inMemoryDatabase.Customers.Remove(customer));

            var service = new CustomerService(mock.Object);
            service.Delete(dto);

            Assert.False(inMemoryDatabase.Customers.Contains(customer));
        }

        [Fact]
        public void CustomerService_DeleteNotAllowed_ThrowsException()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<ICustomerRepository>();
            var dto = new CustomerDto { Id = 2, CustomerId = "CU10002", Name = "Iris", LastName = "Watson", Email = "iris-watson@gmail.com", Website = "www.facebook.com/asdf", AddressId = 1001,
                Orders = new List<OrderDto> { new OrderDto() { Id = 1, CustomerId = 2, DateOfPurchase = new DateTime(2021, 10, 5) } }
            };

            var service = new CustomerService(mock.Object);
            Assert.Throws<InvalidOperationException>(() => service.Delete(dto));
        }

        [Fact]
        public void CustomerService_GetAllWithFilter_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<ICustomerRepository>();

            mock.Setup(x => x.GetAll(c => c.LastName.Contains("a")))
                .Returns(() => inMemoryDatabase.Customers.Where(c => c.LastName.Contains("a")).ToList());

            var service = new CustomerService(mock.Object);
            var list = service.GetAll(c => c.LastName.Contains("a"));

            Assert.True(list.Count == 6);
        }

        [Fact]
        public void CustomerService_GetAll_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<ICustomerRepository>();

            mock.Setup(x => x.GetAll())
                .Returns(() => inMemoryDatabase.Customers.ToList());

            var service = new CustomerService(mock.Object);
            var list = service.GetAll();

            Assert.True(list.Count == 15);
        }

        [Fact]
        public void CustomerService_GetSingle_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<ICustomerRepository>();
            var dto = new CustomerDto { Id = 4, CustomerId = "CU10004", Name = "Theodore", LastName = "Lowe", Email = "theo.Lowe@bdd_dd.com", Website = "http://lowe.net", AddressId = 1003 };


            mock.Setup(x => x.GetSingle(It.IsAny<int>()))
                .Returns(() => inMemoryDatabase.Customers.Where(c => c.Id == 4).FirstOrDefault());

            var service = new CustomerService(mock.Object);
            var customer = service.GetSingle(4);

            Assert.True(
                customer.Id == dto.Id
                && customer.Name == dto.Name
                && customer.LastName == dto.LastName
                && customer.Website == dto.Website
                && customer.FullName == dto.FullName);
        }

        [Fact]
        public void CustomerService_Update_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<ICustomerRepository>();
            var dto = new CustomerDto { Id = 2, CustomerId = "CU10002", Name = "Max", LastName = "Waton", Email = "iris-watson@gmail.com", Website = "www.facebook.com/asdf", AddressId = 1001 };

            mock.Setup(x => x.Update(It.IsAny<Customer>()))
                .Callback(() =>
                {
                    foreach (var c in inMemoryDatabase.Customers)
                    {
                        if (c.Id == dto.Id)
                        {
                            c.Name = dto.Name;
                            c.LastName = dto.LastName;
                            break;
                        }
                    }
                });

            var service = new CustomerService(mock.Object);
            service.Update(dto);
            var afterUpdate = inMemoryDatabase.Customers.Where(x => x.Id == dto.Id).FirstOrDefault();

            Assert.True(
                dto.Id == afterUpdate.Id
                && dto.Name == afterUpdate.Name
                && dto.LastName == afterUpdate.LastName
                && dto.Website == afterUpdate.Website
                && dto.FullName == dto.FullName);
        }

        [Fact]
        public void CustomerService_UpdateWithPassword_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<ICustomerRepository>();
            var dto = new CustomerDto { Id = 2, CustomerId = "CU10002", Name = "Max", LastName = "Waton", Email = "iris-watson@gmail.com", Password = "abcdhH*DFH23", Website = "www.facebook.com/asdf", AddressId = 1001 };

            mock.Setup(x => x.Update(It.IsAny<Customer>()))
                .Callback(() =>
                {
                    foreach (var c in inMemoryDatabase.Customers)
                    {
                        if (c.Id == dto.Id)
                        {
                            c.Name = dto.Name;
                            c.LastName = dto.LastName;
                            break;
                        }
                    }
                });

            var service = new CustomerService(mock.Object);
            service.Update(dto);
            var afterUpdate = inMemoryDatabase.Customers.Where(x => x.Id == dto.Id).FirstOrDefault();

            Assert.True(
                dto.Id == afterUpdate.Id
                && dto.Name == afterUpdate.Name
                && dto.LastName == afterUpdate.LastName
                && dto.Website == afterUpdate.Website
                && dto.FullName == dto.FullName);
        }
        #endregion

        #region CustomerDto
        [Fact]
        public void CustomerDto_ToString_ReturnsTrue()
        {
            var dto = new CustomerDto { Id = 2, CustomerId = "CU10002", Name = "Max", LastName = "Waton", Email = "iris-watson@gmail.com", Website = "www.facebook.com/asdf", AddressId = 1001 };

            Assert.True(dto.ToString() == "Id; 2; FullName; Max Waton");
        }

        [Fact]
        public void CustomerDto_ValidationMail_ThrowsException()
        {
            Assert.Throws<ApplicationException>(() => new CustomerDto { Id = 2, CustomerId = "CU10002", Name = "Max", LastName = "Waton", Email = "iris-watsongmail.com", Website = "www.facebook.com/asdf", AddressId = 1001 });
        }


        [Fact]
        public void CustomerDto_ValidationWebsite_ThrowsException()
        {
            Assert.Throws<ApplicationException>(() => new CustomerDto { Id = 2, CustomerId = "CU10002", Name = "Max", LastName = "Waton", Email = "iris-watson@gmail.com", Website = "www.facebook@\\.com", AddressId = 1001 });
        }

        [Fact]
        public void CustomerDto_ValidationCustomerIdCU_ThrowsException()
        {
            Assert.Throws<ApplicationException>(() => new CustomerDto { Id = 2, CustomerId = "CD10002", Name = "Max", LastName = "Waton", Email = "iris-watson@gmail.com", Website = "www.facebook@\\.com", AddressId = 1001 });
        }

        [Fact]
        public void CustomerDto_ValidationCustomerIdLength_ThrowsException()
        {
            Assert.Throws<ApplicationException>(() => new CustomerDto { Id = 2, CustomerId = "CU102", Name = "Max", LastName = "Waton", Email = "iris-watson@gmail.com", Website = "www.facebook@\\.com", AddressId = 1001 });
        }

        [Fact]
        public void CustomerDto_ValidationPasswordLength_ThrowsException()
        {
            Assert.Throws<ApplicationException>(() => new CustomerDto { Id = 2, CustomerId = "CU10002", Name = "Max", LastName = "Waton", Email = "iris-watson@gmail.com", Website = "www.facebook.com", Password = "123", AddressId = 1001 });
        }

        [Fact]
        public void CustomerDto_ValidationPasswordDigit_ThrowsException()
        {
            Assert.Throws<ApplicationException>(() => new CustomerDto { Id = 2, CustomerId = "CU10002", Name = "Max", LastName = "Waton", Email = "iris-watson@gmail.com", Website = "www.facebook.com", Password = "asdfCDEH", AddressId = 1001 });
        }

        [Fact]
        public void CustomerDto_ValidationPasswordSpecialCharacter_ThrowsException()
        {
            Assert.Throws<ApplicationException>(() => new CustomerDto { Id = 2, CustomerId = "CU10002", Name = "Max", LastName = "Waton", Email = "iris-watson@gmail.com", Website = "www.facebook.com", Password = "as12CDEH", AddressId = 1001 });
        }
        #endregion
    }
}

using Moq;
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
            var customer = new Customer { Name = "Monica", LastName = "Watson", Email = "watson@outlook.com", Website = "www.monica.com", PasswordSalt = "78920238", PasswordHash = "73A3E02C4DD27B55E06022C50D7D0AFC", AddressId = 1001 };
            var dto = new CustomerDto { Name = "Monica", LastName = "Watson", Email = "watson@outlook.com", Website = "www.monica.com", PasswordSalt = "78920238", PasswordHash = "73A3E02C4DD27B55E06022C50D7D0AFC", AddressId = 1001 };
            
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
            var customer = new Customer { Id = 2, Name = "Iris", LastName = "Watson", Email = "iris-watson@gmail.com", Website = "www.facebook.com/asdf", PasswordSalt = "78920238", PasswordHash = "73A3E02C4DD27B55E06022C50D7D0AFC", AddressId = 1001 };
            var dto = new CustomerDto { Id = 2, Name = "Iris", LastName = "Watson", Email = "iris-watson@gmail.com", Website = "www.facebook.com/asdf", PasswordSalt = "78920238", PasswordHash = "73A3E02C4DD27B55E06022C50D7D0AFC", AddressId = 1001 };
                            
            mock.Setup(x => x.Delete(It.IsAny<Customer>()))
                .Callback(() => inMemoryDatabase.Customers.Remove(customer));

            var service = new CustomerService(mock.Object);
            service.Delete(dto);

            Assert.False(inMemoryDatabase.Customers.Contains(customer));
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
            var dto = new CustomerDto { Id = 4, Name = "Theodore", LastName = "Lowe", Email = "theo.Lowe@bdd_dd.com", Website = "http://lowe.net", PasswordSalt = "09820278", PasswordHash = "236ED504E07B07B0A5A258267A076280", AddressId = 1003 };


            mock.Setup(x => x.GetSingle(It.IsAny<int>()))
                .Returns(() => inMemoryDatabase.Customers.Where(c => c.Id == 4).FirstOrDefault());

            var service = new CustomerService(mock.Object);
            var customer = service.GetSingle(4);

            Assert.True(
                customer.Id == dto.Id
                && customer.Name == dto.Name
                && customer.LastName == dto.LastName
                && customer.Website == dto.Website);
        }

        [Fact]
        public void CustomerService_Update_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<ICustomerRepository>();
            var customer = new Customer { Id = 2, Name = "Max", LastName = "Waton", Email = "iris-watson@gmail.com", Website = "www.facebook.com/asdf", PasswordSalt = "78920238", PasswordHash = "73A3E02C4DD27B55E06022C50D7D0AFC", AddressId = 1001 };
            var dto = new CustomerDto { Id = 2, Name = "Max", LastName = "Waton", Email = "iris-watson@gmail.com", Website = "www.facebook.com/asdf", PasswordSalt = "78920238", PasswordHash = "73A3E02C4DD27B55E06022C50D7D0AFC", AddressId = 1001 };

            mock.Setup(x => x.Update(It.IsAny<Customer>()))
                .Callback(() => {
                    foreach (var c in inMemoryDatabase.Customers)
                    {
                        if (c.Id == customer.Id)
                        {
                            c.Name = customer.Name;
                            c.LastName = customer.LastName;
                            break;
                        }
                    }
                });

            var service = new CustomerService(mock.Object);
            service.Update(dto);
            var afterUpdate = inMemoryDatabase.Customers.Where(x => x.Id == customer.Id).FirstOrDefault();
           
            Assert.True(
                customer.Id == afterUpdate.Id
                && customer.Name == afterUpdate.Name
                && customer.LastName == afterUpdate.LastName
                && customer.Website == afterUpdate.Website);
        }
        #endregion
    }
}

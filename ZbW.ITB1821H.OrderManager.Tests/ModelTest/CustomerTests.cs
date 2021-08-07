using System.Linq;
using Xunit;
using ZbW.ITB1821H.OrderManager.Model;
using ZbW.ITB1821H.OrderManager.Model.Repository;
using ZbW.ITB1821H.OrderManager.Model.Service;

namespace ZbW.ITB1821H.OrderManager.Tests.ModelTest
{
    public class CustomerTests : TestingDb
    {
        #region Repository
        [Fact]
        public void CustomerRepositoryAdd_AddNewCustomer_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new CustomerRepository(DbContext);
                var customer = new Customer { Name = "Monica", LastName = "Watson", Email = "watson@outlook.com", Website = "www.monica.com", PasswordSalt = "78920238", PasswordHash = "73A3E02C4DD27B55E06022C50D7D0AFC", AddressId = 1001 };
                repo.Add(customer);
                var customersContext = DbContext.Customers.ToList();

                Assert.True(customersContext.Contains(customer) == true);
            }
        }

        [Fact]
        public void CustomerRepositoryCountWithFilter_CountCustomers_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new CustomerRepository(DbContext);
                var customersContext = DbContext.Customers.Where(x => x.LastName.Contains("a")).ToList();
                
                Assert.True(repo.Count(x => x.LastName.Contains("a")) == customersContext.Count);
            }
        }

        [Fact]
        public void CustomerRepositoryCount_CountCustomers_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new CustomerRepository(DbContext);
                
                Assert.True(repo.Count() == DbContext.Customers.Count());
            }
        }

        [Fact]
        public void CustomerRepositoryDelete_DeleteCustomer_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new CustomerRepository(DbContext);
                var customer = new Customer { Id = 14 };
                repo.Delete(customer);
                var customersContext = DbContext.Customers.ToList();
                
                Assert.True(customersContext.Contains(customer) == false && customersContext.Count == 14);
            }
        }

        [Fact]
        public void CustomerRepositoryGetAll_GetAllCustomersWithFilter_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new CustomerRepository(DbContext);
                var customersContext = DbContext.Customers.Where(x => x.Name.StartsWith("C")).ToList();
                var customers = repo.GetAll(x => x.Name.StartsWith("C"));
                
                Assert.True(customers.Count == customersContext.Count);
            }
        }

        [Fact]
        public void CustomerRepositoryGetAll_GetAllCustomers_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new CustomerRepository(DbContext);
                var customersContext = DbContext.Customers.ToList();
                var customers = repo.GetAll();
                
                Assert.True(customers.Count == customersContext.Count);
            }
        }

        [Fact]
        public void CustomerRepositoryGetSingle_GetSingleCustomerObject_ReturnsEqual()
        {
            using (DbContext)
            {
                var repo = new CustomerRepository(DbContext);
                var customerContext = DbContext.Customers.Where(x => x.Id == 12).SingleOrDefault();
                var customer = repo.GetSingle(12);
                
                Assert.Equal(customer, customerContext);
            }
        }

        [Fact]
        public void CustomerRepositoryUpdate_UpdateCustomer_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new CustomerRepository(DbContext);
                var customerContext = DbContext.Customers.Where(x => x.Id == 7).SingleOrDefault();
                customerContext.Name = "John";
                repo.Update(customerContext);
                var customerContextAfterUpdate = DbContext.Customers.Where(x => x.Id == 7).SingleOrDefault();
                
                Assert.True(customerContextAfterUpdate.Name == "John");
            }
        }
        #endregion Repository

        #region Service
        // Setter Tests in service do not work, because of the Sqlitedb (Dispose after connection closed)

        [Fact]
        public void CustomerServiceCount_CountCustomersWithFilter_ReturnsTrue()
        {
            var service = new CustomerService(OptionsBuilder);
            var customersContext = DbContext.Customers.Where(x => x.LastName.Contains("a")).ToList();

            Assert.True(service.Count(x => x.LastName.Contains("a")) == customersContext.Count);
        }

        [Fact]
        public void CustomerServiceCount_CountCustomers_ReturnsTrue()
        {
            var service = new CustomerService(OptionsBuilder);
            var customersContext = DbContext.Customers.ToList();

            Assert.True(service.Count() == customersContext.Count);
        }

        [Fact]
        public void CustomerServiceGetAll_GetAllCustomersWithFilter_ReturnsTrue()
        {
            var service = new CustomerService(OptionsBuilder);
            var customersContext = DbContext.Customers.Where(x => x.Name.StartsWith("C")).ToList();
            var customers = service.GetAll(x => x.Name.StartsWith("C"));

            Assert.Equal(customers.Count(), customersContext.Count());
        }

        [Fact]
        public void CustomerServiceGetAll_GetAllCustomers_ReturnsTrue()
        {
            var service = new CustomerService(OptionsBuilder);
            var customersContext = DbContext.Customers.ToList();
            var customers = service.GetAll();

            Assert.True(customers.Count() == customersContext.Count());
        }

        [Fact]
        public void CustomerServiceGetSingle_GetSingleCustomer_ReturnsTrue()
        {
            var service = new CustomerService(OptionsBuilder);
            var customerContext = DbContext.Customers.Where(x => x.Id == 12).SingleOrDefault();
            var customer = service.GetSingle(12);

            Assert.True(
                customer.Id == customerContext.Id
                && customer.Name == customerContext.Name
                && customer.LastName == customerContext.LastName
                && customer.Website == customerContext.Website);
        }
        #endregion Service
    }
}

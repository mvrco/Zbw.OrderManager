using System.Linq;
using Xunit;
using ZbW.ITB1821H.OrderManager.Model;
using ZbW.ITB1821H.OrderManager.Model.Repository;
using ZbW.ITB1821H.OrderManager.Model.Service;

namespace ZbW.ITB1821H.OrderManager.Tests.ModelTest
{
    public class AddressTests : TestingDb
    {
        #region Repository
        [Fact]
        public void AddressRepositoryAdd_AddNewAddress_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new AddressRepository(DbContext);
                var address = new Address { Id = 1200, Street = "711 Nulla St.", City = "Mankato", State = "MS", PostalCode = "96522", Country = "US" };
                repo.Add(address);
                var addressesContext = DbContext.Addresses.ToList();

                Assert.True(addressesContext.Contains(address) == true);
            }
        }

        [Fact]
        public void AddressRepositoryCountWithFilter_CountAddresses_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new AddressRepository(DbContext);
                var addressesContext = DbContext.Addresses.Where(x => x.City.Contains("a")).ToList();

                Assert.True(repo.Count(x => x.City.Contains("a")) == addressesContext.Count);
            }
        }

        [Fact]
        public void AddressRepositoryCount_CountAddresses_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new AddressRepository(DbContext);

                Assert.True(repo.Count() == DbContext.Addresses.Count());
            }
        }

        [Fact]
        public void AddressRepositoryDelete_DeleteAddress_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new AddressRepository(DbContext);
                var address = new Address { Id = 1000 };
                repo.Delete(address);
                var addressesContext = DbContext.Addresses.ToList();

                Assert.True(!addressesContext.Contains(address) && addressesContext.Count == 20);
            }
        }

        [Fact]
        public void AddressRepositoryGetAll_GetAllAddressesWithFilter_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new AddressRepository(DbContext);
                var addressesContext = DbContext.Addresses.Where(x => x.State.StartsWith("N")).ToList();
                var addresses = repo.GetAll(x => x.State.StartsWith("N"));

                Assert.True(addresses.Count == addressesContext.Count);
            }
        }

        [Fact]
        public void AddressRepositoryGetAll_GetAllAddresses_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new AddressRepository(DbContext);
                var addressesContext = DbContext.Addresses.ToList();
                var addresses = repo.GetAll();

                Assert.True(addresses.Count == addressesContext.Count);
            }
        }

        [Fact]
        public void AddressRepositoryGetSingle_GetSingleAddressObject_ReturnsEqual()
        {
            using (DbContext)
            {
                var repo = new AddressRepository(DbContext);
                var addressContext = DbContext.Addresses.Where(x => x.Id == 1005).SingleOrDefault();
                var address = repo.GetSingle(1005);

                Assert.Equal(address, addressContext);
            }
        }

        [Fact]
        public void AddressRepositoryUpdate_UpdateAddress_ReturnsTrue()
        {
            using (DbContext)
            {
                var repo = new AddressRepository(DbContext);
                var addressContext = DbContext.Addresses.Where(x => x.Id == 1006).SingleOrDefault();
                addressContext.State = "NY";
                repo.Update(addressContext);
                var addressContextAfterUpdate = DbContext.Addresses.Where(x => x.Id == 1006).SingleOrDefault();

                Assert.True(addressContextAfterUpdate.State == "NY");
            }
        }
        #endregion Repository

        #region Service
        [Fact]
        public void AddressServiceCount_CountAdressesWithFilter_ReturnsTrue()
        {
            var service = new AddressService(OptionsBuilder);
            var addressesContext = DbContext.Addresses.Where(x => x.City.Contains("a")).ToList();

            Assert.True(service.Count(x => x.City.Contains("a")) == addressesContext.Count);
        }

        [Fact]
        public void AddressServiceCount_CountCustomers_ReturnsTrue()
        {
            var service = new AddressService(OptionsBuilder);            

            Assert.True(service.Count() == DbContext.Addresses.Count());
        }

        [Fact]
        public void AddressServiceGetAll_GetAllAddressesWithFilter_ReturnsTrue()
        {
            var service = new AddressService(OptionsBuilder);
            var addressesContext = DbContext.Addresses.Where(x => x.State.StartsWith("N")).ToList();
            var addresses = service.GetAll(x => x.State.StartsWith("N"));

            Assert.True(addresses.Count == addressesContext.Count);
        }

        [Fact]
        public void AddressServiceGetAll_GetAllAddresses_ReturnsTrue()
        {
            var service = new AddressService(OptionsBuilder);
            var addressesContext = DbContext.Addresses.ToList();
            var addresses = service.GetAll();

            Assert.True(addresses.Count == addressesContext.Count);
        }

        [Fact]
        public void AddressServiceGetSingle_GetSingleAddress_ReturnsTrue()
        {
            var service = new AddressService(OptionsBuilder);
            var addressContext = DbContext.Addresses.Where(x => x.Id == 1000).SingleOrDefault();
            var address = service.GetSingle(1000);

            Assert.True(
                address.Id == addressContext.Id
                && address.City == addressContext.City
                && address.State == addressContext.State
                && address.Country == addressContext.Country);
        }
        #endregion Service
    }
}

using Moq;
using System.Linq;
using Xunit;
using ZbW.ITB1821H.OrderManager.Model.Dto;
using ZbW.ITB1821H.OrderManager.Model.Entities;
using ZbW.ITB1821H.OrderManager.Model.Repository.Interfaces;
using ZbW.ITB1821H.OrderManager.Model.Service;

namespace ZbW.ITB1821H.OrderManager.Tests.ModelTest
{
    public class AddressTests
    {
        #region Address Service/Repository
        [Fact]
        public void AddressService_Add_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IAddressRepository>();
            var address = new Address { Street = "153 Wood St.", City = "Ocean Springs", State = "MS", PostalCode = "39564", Country = "US" };
            var dto = new AddressDto { Street = "153 Wood St.", City = "Ocean Springs", State = "MS", PostalCode = "39564", Country = "US" };

            mock.Setup(x => x.Add(It.IsAny<Address>()))
                .Callback(() => inMemoryDatabase.Addresses.Add(address));

            var service = new AddressService(mock.Object);
            service.Add(dto);

            Assert.True(inMemoryDatabase.Addresses.Contains(address));
        }

        [Fact]
        public void AddressService_CountWithFilter_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IAddressRepository>();

            mock.Setup(x => x.Count(a => a.State == "MS"))
                .Returns(() => inMemoryDatabase.Addresses.Where(a => a.State == "MS").Count());

            var service = new AddressService(mock.Object);
            var count = service.Count(a => a.State == "MS");

            Assert.True(count == 2);
        }

        [Fact]
        public void AddressService_Count_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IAddressRepository>();

            mock.Setup(x => x.Count())
                .Returns(() => inMemoryDatabase.Addresses.Count);

            var service = new AddressService(mock.Object);
            var count = service.Count();

            Assert.True(count == 21);
        }

        [Fact]
        public void AddressService_Delete_ReturnsFalse()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IAddressRepository>();
            var address = new Address { Id = 1009, Street = "153 Wood St.", City = "Ocean Springs", State = "MS", PostalCode = "39564", Country = "US" };
            var dto = new AddressDto { Id = 1009, Street = "153 Wood St.", City = "Ocean Springs", State = "MS", PostalCode = "39564", Country = "US" };

            mock.Setup(x => x.Delete(It.IsAny<Address>()))
                .Callback(() => inMemoryDatabase.Addresses.Remove(address));

            var service = new AddressService(mock.Object);
            service.Delete(dto);

            Assert.False(inMemoryDatabase.Addresses.Contains(address));
        }

        [Fact]
        public void AddressService_GetAllWithFilter_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IAddressRepository>();

            mock.Setup(x => x.GetAll(a => a.State == "MS"))
                .Returns(() => inMemoryDatabase.Addresses.Where(a => a.State == "MS").ToList());

            var service = new AddressService(mock.Object);
            var list = service.GetAll(a => a.State == "MS");

            Assert.True(list.Count == 2);
        }

        [Fact]
        public void AddressService_GetAll_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IAddressRepository>();

            mock.Setup(x => x.GetAll())
                .Returns(() => inMemoryDatabase.Addresses.ToList());

            var service = new AddressService(mock.Object);
            var list = service.GetAll();

            Assert.True(list.Count == 21);
        }

        [Fact]
        public void AddressService_GetSingle_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IAddressRepository>();
            var dto = new AddressDto { Id = 1009, Street = "153 Wood St.", City = "Ocean Springs", State = "MS", PostalCode = "39564", Country = "US" };


            mock.Setup(x => x.GetSingle(It.IsAny<int>()))
                .Returns(() => inMemoryDatabase.Addresses.Where(a => a.Id == 1009).FirstOrDefault());

            var service = new AddressService(mock.Object);
            var address = service.GetSingle(1009);

            Assert.True(
                address.Id == dto.Id
                && address.Street == dto.Street
                && address.City == dto.City
                && address.State == dto.State);
        }

        [Fact]
        public void AddressService_Update_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IAddressRepository>();
            var address = new Address { Id = 1009, Street = "153 Wood St.", City = "Wave Springs", State = "CA", PostalCode = "39564", Country = "US" };
            var dto = new AddressDto { Id = 1009, Street = "153 Wood St.", City = "Wave Springs", State = "CA", PostalCode = "39564", Country = "US" };

            mock.Setup(x => x.Update(It.IsAny<Address>()))
                .Callback(() => {
                    foreach (var a in inMemoryDatabase.Addresses)
                    {
                        if (a.Id == address.Id)
                        {
                            a.City = address.City;
                            a.State = address.State;
                            break;
                        }
                    }
                });

            var service = new AddressService(mock.Object);
            service.Update(dto);
            var afterUpdate = inMemoryDatabase.Addresses.Where(x => x.Id == address.Id).FirstOrDefault();

            Assert.True(
                address.Id == afterUpdate.Id
                && address.City == afterUpdate.City
                && address.State == afterUpdate.State);
        }
        #endregion
    }
}

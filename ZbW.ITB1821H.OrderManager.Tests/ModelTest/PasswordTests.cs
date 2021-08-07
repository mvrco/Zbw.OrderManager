using Xunit;
using ZbW.ITB1821H.OrderManager.Model;
using ZbW.ITB1821H.OrderManager.Model.Service;

namespace ZbW.ITB1821H.OrderManager.Tests.ModelTest
{
    public class PasswordTests
    {
        [Fact]
        public void PasswordServiceHashPassword_HashesThePasswordAndStoresToCustomerObject_ReturnsTrue()
        {
            var service = new PasswordService();
            var customer = new Customer { Id = 1, Name = "Cecilia", LastName = "Chapman", Email = "cecilia@chapman.com", Website = "https://chapman.com", AddressId = 1000 };

            service.HashPassword("testpw1234", customer);

            Assert.True(customer.PasswordHash != null && customer.PasswordSalt != null);
        }

        [Fact]
        public void PasswordServiceComparePassword_ComparesPasswordWithSavedPAssword_ReturnsTrue()
        {
            var service = new PasswordService();
            var customer = new Customer { Id = 1, Name = "Cecilia", LastName = "Chapman", Email = "cecilia@chapman.com", Website = "https://chapman.com", PasswordSalt = "12837163", PasswordHash = "E14CE3435BC3194B77C609F26EF6075E", AddressId = 1000 };

            Assert.True(service.ComparePassword("q-9L8?Ac", customer));
        }
    }
}

using Moq;
using System.Linq;
using Xunit;
using ZbW.ITB1821H.OrderManager.Model.Repository.Interfaces;
using ZbW.ITB1821H.OrderManager.Model.Service;

namespace ZbW.ITB1821H.OrderManager.Tests.ModelTest
{
    public class InvoiceTests
    {
        #region Invoice Service/Repository
        [Fact]
        public void InvoiceService_Get_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IInvoiceRepository>();

            mock.Setup(x => x.Get())
                .Returns(() => inMemoryDatabase.Invoices.ToList());

            var service = new InvoiceService(mock.Object);
            var invoices = service.Get();

            Assert.True(invoices.Count == 4);
        }
        #endregion
    }
}

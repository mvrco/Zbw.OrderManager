using Moq;
using System.Linq;
using Xunit;
using ZbW.ITB1821H.OrderManager.Model.Repository.Interfaces;
using ZbW.ITB1821H.OrderManager.Model.Service;

namespace ZbW.ITB1821H.OrderManager.Tests.ModelTest
{
    public class QuartalsReportingTests
    {
        #region QuartalsReportiong Service/Repository
        [Fact]
        public void QuartalsReportingService_Get_ReturnsTrue()
        {
            var inMemoryDatabase = new InMemoryDatabase();
            var mock = new Mock<IQuartalsReportingRepository>();

            mock.Setup(x => x.Get())
                .Returns(() => inMemoryDatabase.QuarterReportings.ToList());

            var service = new QuartalsReportingService(mock.Object);
            var reportings = service.Get();

            Assert.True(reportings.Count == 4);
        }
        #endregion
    }
}

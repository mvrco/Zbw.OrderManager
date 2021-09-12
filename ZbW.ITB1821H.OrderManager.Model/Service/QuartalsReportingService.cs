
using ZbW.ITB1821H.OrderManager.Model.Dto;
using ZbW.ITB1821H.OrderManager.Model.Entities;
using ZbW.ITB1821H.OrderManager.Model.Repository.Interfaces;
using ZbW.ITB1821H.OrderManager.Model.Service.Interfaces;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
    public class QuartalsReportingService : ReportingServiceBase<QuartalsReporting, QuartalsReportingDto>, IQuartalsReportingService
    {
        public QuartalsReportingService(IQuartalsReportingRepository repo) : base(repo) { }
    }
}

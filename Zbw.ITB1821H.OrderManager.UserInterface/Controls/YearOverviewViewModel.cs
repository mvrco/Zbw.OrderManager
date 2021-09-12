using log4net;
using System.Collections.Generic;
using ZbW.ITB1821H.OrderManager.Controls;
using ZbW.ITB1821H.OrderManager.Model.Dto;
using ZbW.ITB1821H.OrderManager.Model.Repository;
using ZbW.ITB1821H.OrderManager.Model.Service;

namespace ZbW.ITB1821H.OrderManager.UserInterface.Controls
{
    public class YearOverviewPageViewModel : BaseViewModel
    {
        private QuartalsReportingService _quartalsReportingService;
        public YearOverviewPageViewModel() : base(LogManager.GetLogger(nameof(YearOverviewPageViewModel)))
        {
            _quartalsReportingService = new QuartalsReportingService(new QuartalsReportingRepository());
            Reports = _quartalsReportingService.Get();
        }

        public IList<QuartalsReportingDto> Reports { get; set; }
    }
}

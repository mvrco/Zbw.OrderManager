using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.ITB1821H.OrderManager.Model.Context;
using ZbW.ITB1821H.OrderManager.Model.Entities;
using ZbW.ITB1821H.OrderManager.Model.Repository.Interfaces;

namespace ZbW.ITB1821H.OrderManager.Model.Repository
{
    public class QuartalsReportingRepository : IQuartalsReportingRepository
    {
        public new List<QuartalsReporting> Get()
        {
            using (var context = new DatabaseContext())
            {
                return context.GetQuartalsReportings().ToList();
            }
        }
    }
}

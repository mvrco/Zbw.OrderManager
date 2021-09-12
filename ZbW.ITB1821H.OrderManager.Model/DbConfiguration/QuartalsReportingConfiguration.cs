using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.ITB1821H.OrderManager.Model.Entities;

namespace ZbW.ITB1821H.OrderManager.Model.DbConfiguration
{
    public class QuartalsReportingConfiguration : IEntityTypeConfiguration<QuartalsReporting>
    { 
        public void Configure(EntityTypeBuilder<QuartalsReporting> builder)
        {
            builder.HasKey(x => x.Category);
        }
    }
}

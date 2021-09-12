using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZbW.ITB1821H.OrderManager.Model.Entities;

namespace ZbW.ITB1821H.OrderManager.Model.DbConfiguration
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(x => x.OrderId);
        }
    }
}

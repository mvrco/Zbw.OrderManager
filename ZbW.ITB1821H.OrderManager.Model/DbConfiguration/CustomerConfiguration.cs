using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZbW.ITB1821H.OrderManager.Model.DbConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(cus => cus.Address)
                .WithMany(adr => adr.Customers)
                .HasForeignKey(cus => cus.AdressId);
                .HasForeignKey(cus => cus.AddressId);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
        }
    }
}

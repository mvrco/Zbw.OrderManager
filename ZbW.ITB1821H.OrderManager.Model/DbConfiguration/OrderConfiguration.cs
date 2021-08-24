using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using ZbW.ITB1821H.OrderManager.Model.Entities;

namespace ZbW.ITB1821H.OrderManager.Model.DbConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(ord => ord.Customer)
                .WithMany(cus => cus.Orders)
                .HasForeignKey(ord => ord.CustomerId);

            builder.HasData(
                 new Order { Id = 1234, DateOfPurchase = new DateTime(2021, 1, 30), CustomerId = 1 },
                 new Order { Id = 1235, DateOfPurchase = new DateTime(2021, 1, 23), CustomerId = 2},
                 new Order { Id = 1236, DateOfPurchase = new DateTime(2021, 1, 2), CustomerId = 2},
                 new Order { Id = 1237, DateOfPurchase = new DateTime(2021, 2, 4), CustomerId = 2},
                 new Order { Id = 1238, DateOfPurchase = new DateTime(2021, 2, 3), CustomerId = 3 },
                 new Order { Id = 1239, DateOfPurchase = new DateTime(2021, 2, 22), CustomerId = 3 },
                 new Order { Id = 1230, DateOfPurchase = new DateTime(2021, 3, 31), CustomerId = 4 },
                 new Order { Id = 1240, DateOfPurchase = new DateTime(2021, 3, 1), CustomerId = 4 },
                 new Order { Id = 1231, DateOfPurchase = new DateTime(2021, 3, 25), CustomerId = 6 },
                 new Order { Id = 1232, DateOfPurchase = new DateTime(2020, 12, 12), CustomerId = 7 },
                 new Order { Id = 1233, DateOfPurchase = new DateTime(2020, 12, 1), CustomerId = 8 },
                 new Order { Id = 1241, DateOfPurchase = new DateTime(2020, 11, 22), CustomerId = 8 },
                 new Order { Id = 1242, DateOfPurchase = new DateTime(2020, 10, 9), CustomerId = 10 },
                 new Order { Id = 1243, DateOfPurchase = new DateTime(2021, 5, 8), CustomerId = 11 },
                 new Order { Id = 1244, DateOfPurchase = new DateTime(2021, 3, 7), CustomerId = 11 },
                 new Order { Id = 1245, DateOfPurchase = new DateTime(2021, 4, 3), CustomerId = 11 },
                 new Order { Id = 1246, DateOfPurchase = new DateTime(2021, 4, 5), CustomerId = 14 },
                 new Order { Id = 1247, DateOfPurchase = new DateTime(2021, 3, 14), CustomerId = 15 },
                 new Order { Id = 1248, DateOfPurchase = new DateTime(2021, 4, 17), CustomerId = 15 }
              );
        }
    }
}

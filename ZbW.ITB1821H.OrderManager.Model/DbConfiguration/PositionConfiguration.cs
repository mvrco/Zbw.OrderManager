using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZbW.ITB1821H.OrderManager.Model.DbConfiguration
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(pos => pos.Article)
                .WithMany(art => art.Positions)
                .HasForeignKey(pos => pos.ArticleId);

            builder
                .HasOne(pos => pos.Order)
                .WithMany(ord => ord.Positions)
                .HasForeignKey(pos => pos.OrderId);

            builder.Property(x => x.ArticleId).IsRequired();
            builder.Property(x => x.OrderId).IsRequired();
            
            builder.HasData(
                  new Position { Id = 1, PosNr = 1, OrderId = 1230, Amount = 23, ArticleId = 100 },
                  new Position { Id = 2, PosNr = 2, OrderId = 1230, Amount = 30, ArticleId = 101 },
                  new Position { Id = 3, PosNr = 3, OrderId = 1230, Amount = 12, ArticleId = 102 },
                  new Position { Id = 4, PosNr = 4, OrderId = 1230, Amount = 34, ArticleId = 103 },
                  new Position { Id = 5, PosNr = 1, OrderId = 1231, Amount = 100, ArticleId = 100 },
                  new Position { Id = 6, PosNr = 2, OrderId = 1231, Amount = 200, ArticleId = 102 },
                  new Position { Id = 7, PosNr = 1, OrderId = 1232, Amount = 55, ArticleId = 104 },
                  new Position { Id = 8, PosNr = 2, OrderId = 1232, Amount = 35, ArticleId = 105 },
                  new Position { Id = 9, PosNr = 3, OrderId = 1232, Amount = 20, ArticleId = 100 },
                  new Position { Id = 10, PosNr = 4, OrderId = 1232, Amount = 10, ArticleId = 101 },
                  new Position { Id = 11, PosNr = 5, OrderId = 1232, Amount = 5, ArticleId = 102 },
                  new Position { Id = 12, PosNr = 6, OrderId = 1232, Amount = 50, ArticleId = 103 },
                  new Position { Id = 13, PosNr = 1, OrderId = 1233, Amount = 86, ArticleId = 100 },
                  new Position { Id = 14, PosNr = 2, OrderId = 1233, Amount = 134, ArticleId = 101 },
                  new Position { Id = 15, PosNr = 3, OrderId = 1233, Amount = 100, ArticleId = 102 },
                  new Position { Id = 16, PosNr = 4, OrderId = 1233, Amount = 90, ArticleId = 103 },
                  new Position { Id = 17, PosNr = 1, OrderId = 1234, Amount = 134, ArticleId = 103 },
                  new Position { Id = 18, PosNr = 2, OrderId = 1234, Amount = 56, ArticleId = 104 },
                  new Position { Id = 19, PosNr = 3, OrderId = 1234, Amount = 65, ArticleId = 105 },
                  new Position { Id = 20, PosNr = 1, OrderId = 1235, Amount = 73, ArticleId = 103 },
                  new Position { Id = 21, PosNr = 2, OrderId = 1235, Amount = 77, ArticleId = 105 },
                  new Position { Id = 22, PosNr = 1, OrderId = 1236, Amount = 98, ArticleId = 105 },
                  new Position { Id = 23, PosNr = 2, OrderId = 1236, Amount = 123, ArticleId = 104 },
                  new Position { Id = 24, PosNr = 1, OrderId = 1237, Amount = 451, ArticleId = 103 },
                  new Position { Id = 25, PosNr = 2, OrderId = 1237, Amount = 345, ArticleId = 102 },
                  new Position { Id = 26, PosNr = 1, OrderId = 1238, Amount = 557, ArticleId = 100 },
                  new Position { Id = 27, PosNr = 2, OrderId = 1238, Amount = 45, ArticleId = 101 },
                  new Position { Id = 28, PosNr = 3, OrderId = 1238, Amount = 256, ArticleId = 102 },
                  new Position { Id = 29, PosNr = 4, OrderId = 1238, Amount = 234, ArticleId = 103 },
                  new Position { Id = 30, PosNr = 5, OrderId = 1238, Amount = 56, ArticleId = 104 },
                  new Position { Id = 31, PosNr = 6, OrderId = 1238, Amount = 134, ArticleId = 105 },
                  new Position { Id = 32, PosNr = 1, OrderId = 1239, Amount = 567, ArticleId = 104 },
                  new Position { Id = 33, PosNr = 2, OrderId = 1239, Amount = 87, ArticleId = 105 },
                  new Position { Id = 34, PosNr = 1, OrderId = 1240, Amount = 47, ArticleId = 101 },
                  new Position { Id = 35, PosNr = 1, OrderId = 1241, Amount = 83, ArticleId = 102 },
                  new Position { Id = 36, PosNr = 2, OrderId = 1241, Amount = 95, ArticleId = 103 },
                  new Position { Id = 37, PosNr = 1, OrderId = 1242, Amount = 75, ArticleId = 104 },
                  new Position { Id = 38, PosNr = 2, OrderId = 1242, Amount = 45, ArticleId = 105 },
                  new Position { Id = 39, PosNr = 3, OrderId = 1242, Amount = 75, ArticleId = 100 },
                  new Position { Id = 40, PosNr = 1, OrderId = 1243, Amount = 25, ArticleId = 102 },
                  new Position { Id = 41, PosNr = 2, OrderId = 1243, Amount = 35, ArticleId = 103 },
                  new Position { Id = 42, PosNr = 1, OrderId = 1244, Amount = 51, ArticleId = 105 },
                  new Position { Id = 43, PosNr = 1, OrderId = 1245, Amount = 15, ArticleId = 103 },
                  new Position { Id = 44, PosNr = 2, OrderId = 1245, Amount = 36, ArticleId = 104 },
                  new Position { Id = 45, PosNr = 3, OrderId = 1245, Amount = 99, ArticleId = 105 },
                  new Position { Id = 46, PosNr = 1, OrderId = 1246, Amount = 100, ArticleId = 100 },
                  new Position { Id = 47, PosNr = 1, OrderId = 1247, Amount = 35, ArticleId = 101 },
                  new Position { Id = 48, PosNr = 1, OrderId = 1248, Amount = 75, ArticleId = 102 }
              );
        }
    }
}

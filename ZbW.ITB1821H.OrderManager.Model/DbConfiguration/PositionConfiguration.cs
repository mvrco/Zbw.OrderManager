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
        }
    }
}

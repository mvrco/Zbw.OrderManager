using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZbW.ITB1821H.OrderManager.Model.DbConfiguration
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(art => art.ArticleGroup)
                .WithMany(artG => artG.Articles)
                .HasForeignKey(art => art.ArticleGroupId);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Price).IsRequired();

            builder.Property(x => x.CreateDate).HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnAdd();
            builder.Property(X => X.IsActive).HasDefaultValue(true).ValueGeneratedOnAdd();

            builder.HasData(
              new Article { Id = 100, Name = "Apple", Description = "Fresh from Switzerland", Price = 0.95, ArticleGroupId = 11 },
              new Article { Id = 101, Name = "Banana", Description = "Fresh from Columbia", Price = 1.12, ArticleGroupId = 11 },
              new Article { Id = 102, Name = "Chicken", Description = "Swiss Quality", Price = 2.03, ArticleGroupId = 12 },
              new Article { Id = 103, Name = "Salmon", Description = "Atlantic Ocean", Price = 1.56, ArticleGroupId = 12 },
              new Article { Id = 104, Name = "Cheese", Description = "Switzerland", Price = 2.22, ArticleGroupId = 13 },
              new Article { Id = 105, Name = "Yogurt", Description = "Based on years of experience", Price = 2.34, ArticleGroupId = 13 }
              );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZbW.ITB1821H.OrderManager.Model.DbConfiguration
{
    public class ArticleGroupConfiguration : IEntityTypeConfiguration<ArticleGroup>
    {
        public void Configure(EntityTypeBuilder<ArticleGroup> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(artG => artG.ParentGroup)
                .WithMany(artGPar => artGPar.SubArticleGroups)
                .HasForeignKey(artG => artG.ParentGroupId);

            builder.Property(x => x.Name).IsRequired();

            builder.HasData(
                new ArticleGroup { Id = 10, Name = "Food", Description = "all food" },
                new ArticleGroup { Id = 11, Name = "Fruits", Description = "Worldwide selection of Fruits", ParentGroupId = 10 },
                new ArticleGroup { Id = 12, Name = "Meat", Description = "Good Quality Meat", ParentGroupId = 10 },
                new ArticleGroup { Id = 13, Name = "Dairy", Description = "Milk for everyone!", ParentGroupId = 10 }
            );
        }
    }
}

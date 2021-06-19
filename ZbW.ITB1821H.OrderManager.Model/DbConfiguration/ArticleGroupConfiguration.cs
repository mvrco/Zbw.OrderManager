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
        }
    }
}

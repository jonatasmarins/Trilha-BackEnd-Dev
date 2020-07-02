using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nivel1.Domain.ExternalServices.Marvel.Models;

namespace Nivel1.Data.ConfigurationBuilders
{
    public class ComicCreatorConfiguration : IEntityTypeConfiguration<ComicCreator>
    {
        public void Configure(EntityTypeBuilder<ComicCreator> builder)
        {
            builder.HasKey(t => new {t.CreatorID, t.ComicID});

            builder.HasOne(pt => pt.Comic)
                .WithMany(p => p.Creators)
                .HasForeignKey(pt => pt.ComicID);
        }
    }
}
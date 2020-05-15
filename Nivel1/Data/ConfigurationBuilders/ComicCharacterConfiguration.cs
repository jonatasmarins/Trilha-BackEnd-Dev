using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nivel1.Domain.ExternalServices.Marvel.Models;

namespace Nivel1.Data.ConfigurationBuilders
{
    public class ComicCharacterConfiguration : IEntityTypeConfiguration<ComicCharacter>
    {
        public void Configure(EntityTypeBuilder<ComicCharacter> builder)
        {
            builder.HasKey(t => new {t.CharacterID, t.ComicID});

            builder.HasOne(pt => pt.Comic)
                .WithMany(p => p.Characters)
                .HasForeignKey(pt => pt.ComicID);
        }
    }
}
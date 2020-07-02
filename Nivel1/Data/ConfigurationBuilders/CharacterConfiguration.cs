using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nivel1.Domain.ExternalServices.Models;

namespace Nivel1.Data.ConfigurationBuilders
{
    public class CharacterConfiguration: IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.ToTable("Character");
            builder.HasKey(x => x.CharacterID).HasName("PrimaryKey_CharacterID");
            builder.Property(x => x.CharacterID).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.HasIndex(x => x.Code).IsUnique();
            builder.Property(x => x.Code).IsRequired();
        }
    }
}
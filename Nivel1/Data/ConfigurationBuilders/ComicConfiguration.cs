using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nivel1.Domain.ExternalServices.Models;

namespace Nivel1.Data.ConfigurationBuilders
{
    public class ComicConfiguration : IEntityTypeConfiguration<Comic>
    {
        public void Configure(EntityTypeBuilder<Comic> builder)
        {
            builder.ToTable("Comic");
            builder.HasKey(x => x.ComicID).HasName("PrimaryKey_ComicID");
            builder.Property(x => x.ComicID).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.HasIndex(x => x.Code).IsUnique().HasName("Code_Comic");
            builder.Property(x => x.Code).IsRequired();
        }
    }
}
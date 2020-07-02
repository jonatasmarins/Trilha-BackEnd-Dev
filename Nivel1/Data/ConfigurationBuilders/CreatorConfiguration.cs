using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nivel1.Domain.ExternalServices.Models;

namespace Nivel1.Data.ConfigurationBuilders
{
    public class CreatorConfiguration: IEntityTypeConfiguration<Creator>
    {
        public void Configure(EntityTypeBuilder<Creator> builder)
        {
            builder.ToTable("Creator");
            builder.HasKey(x => x.CreatorID).HasName("PrimaryKey_CreatorID");
            builder.Property(x => x.CreatorID).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.HasIndex(x => x.Code).IsUnique();
            builder.Property(x => x.Code).IsRequired();
        }
    }
}
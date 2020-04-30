using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nivel1.Domain.Models;

namespace Nivel1.Data.ConfigurationBuilders
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id).HasName("Id");
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.OwnsOne(x => x.Document, sa =>
            {
                sa.Property(p => p.Value)
                    .HasColumnName("Document")
                    .HasMaxLength(11)
                    .HasDefaultValue("");
            });

            builder.OwnsOne(x => x.Name, sa =>
            {
                sa.Property(p => p.Value)
                .HasColumnName("Name")
                .HasMaxLength(300)
                .HasDefaultValue("");
            });

            builder.OwnsOne(x => x.YearsOld, sa =>
            {
                sa.Property(p => p.Value)
                .HasColumnName("YearOld")
                .HasMaxLength(3);
            });

            builder.OwnsOne(x => x.Email, sa =>
            {
                sa.Property(p => p.Value)
                    .HasColumnName("Email")
                    .HasMaxLength(300)
                    .HasDefaultValue("");
            });
            builder.OwnsOne(x => x.Phone, sa =>
            {
                sa.Property(p => p.Value)
                    .HasColumnName("Phone")
                    .HasMaxLength(11)
                    .HasDefaultValue("");
            });
            builder.Property(x => x.Address)
                .HasColumnName("Address")
                .HasMaxLength(300)
                .HasDefaultValue("");
        }
    }
}
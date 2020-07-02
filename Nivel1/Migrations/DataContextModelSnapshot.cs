﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nivel1.Data.Context;

namespace Nivel1.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Nivel1.Domain.ExternalServices.Marvel.Models.ComicCharacter", b =>
                {
                    b.Property<int>("CharacterID")
                        .HasColumnType("int");

                    b.Property<int>("ComicID")
                        .HasColumnType("int");

                    b.HasKey("CharacterID", "ComicID");

                    b.HasIndex("ComicID");

                    b.ToTable("ComicCharacters");
                });

            modelBuilder.Entity("Nivel1.Domain.ExternalServices.Marvel.Models.ComicCreator", b =>
                {
                    b.Property<int>("CreatorID")
                        .HasColumnType("int");

                    b.Property<int>("ComicID")
                        .HasColumnType("int");

                    b.HasKey("CreatorID", "ComicID");

                    b.HasIndex("ComicID");

                    b.ToTable("ComicCreators");
                });

            modelBuilder.Entity("Nivel1.Domain.ExternalServices.Models.Character", b =>
                {
                    b.Property<int>("CharacterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlWiki")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CharacterID")
                        .HasName("PrimaryKey_CharacterID");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Character");
                });

            modelBuilder.Entity("Nivel1.Domain.ExternalServices.Models.Comic", b =>
                {
                    b.Property<int>("ComicID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Ean")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlWiki")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ComicID")
                        .HasName("PrimaryKey_ComicID");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasName("Code_Comic");

                    b.ToTable("Comic");
                });

            modelBuilder.Entity("Nivel1.Domain.ExternalServices.Models.Creator", b =>
                {
                    b.Property<int>("CreatorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CreatorID")
                        .HasName("PrimaryKey_CreatorID");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Creator");
                });

            modelBuilder.Entity("Nivel1.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Address")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300)
                        .HasDefaultValue("");

                    b.HasKey("Id")
                        .HasName("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Nivel1.Domain.ExternalServices.Marvel.Models.ComicCharacter", b =>
                {
                    b.HasOne("Nivel1.Domain.ExternalServices.Models.Character", "Character")
                        .WithMany("Comics")
                        .HasForeignKey("CharacterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nivel1.Domain.ExternalServices.Models.Comic", "Comic")
                        .WithMany("Characters")
                        .HasForeignKey("ComicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Nivel1.Domain.ExternalServices.Marvel.Models.ComicCreator", b =>
                {
                    b.HasOne("Nivel1.Domain.ExternalServices.Models.Comic", "Comic")
                        .WithMany("Creators")
                        .HasForeignKey("ComicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nivel1.Domain.ExternalServices.Models.Creator", "Creator")
                        .WithMany("Comics")
                        .HasForeignKey("CreatorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Nivel1.Domain.Models.User", b =>
                {
                    b.OwnsOne("Nivel1.Domain.ValueObject.Cpf", "Document", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("Document")
                                .HasColumnType("nvarchar(11)")
                                .HasMaxLength(11)
                                .HasDefaultValue("");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Nivel1.Domain.ValueObject.Email", "Email", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("Email")
                                .HasColumnType("nvarchar(300)")
                                .HasMaxLength(300)
                                .HasDefaultValue("");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Nivel1.Domain.ValueObject.Name", "Name", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("Name")
                                .HasColumnType("nvarchar(300)")
                                .HasMaxLength(300)
                                .HasDefaultValue("");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Nivel1.Domain.ValueObject.Phone", "Phone", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("Phone")
                                .HasColumnType("nvarchar(11)")
                                .HasMaxLength(11)
                                .HasDefaultValue("");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Nivel1.Domain.ValueObject.YearsOld", "YearsOld", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Value")
                                .HasColumnName("YearOld")
                                .HasColumnType("int")
                                .HasMaxLength(3);

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TeamHost.Persistence.Context;

#nullable disable

namespace TeamHost.Persistence.Migrations
{
    [DbContext(typeof(EfContext))]
    [Migration("20240331073741_Fix files")]
    partial class Fixfiles
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CategoryGame", b =>
                {
                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("GamesId")
                        .HasColumnType("uuid");

                    b.HasKey("CategoriesId", "GamesId");

                    b.HasIndex("GamesId");

                    b.ToTable("CategoryGame");
                });

            modelBuilder.Entity("GamePlatform", b =>
                {
                    b.Property<Guid>("GamesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlatformsId")
                        .HasColumnType("uuid");

                    b.HasKey("GamesId", "PlatformsId");

                    b.HasIndex("PlatformsId");

                    b.ToTable("GamePlatform");
                });

            modelBuilder.Entity("TeamHost.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TeamHost.Domain.Entities.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AplhaThree")
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)");

                    b.Property<string>("AplhaTwo")
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)");

                    b.Property<int>("Code")
                        .HasMaxLength(4)
                        .HasColumnType("integer");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("TeamHost.Domain.Entities.Developer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("TeamHost.Domain.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid>("DeveloperId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MainImageId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<float>("Rating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f);

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("MainImageId")
                        .IsUnique();

                    b.ToTable("Games");
                });

            modelBuilder.Entity("TeamHost.Domain.Entities.MediaFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("GameId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Size")
                        .HasColumnType("numeric(20,0)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("MediaFiles");
                });

            modelBuilder.Entity("TeamHost.Domain.Entities.Platform", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<Guid?>("MediaFileId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MediaFileId");

                    b.ToTable("Platform");
                });

            modelBuilder.Entity("CategoryGame", b =>
                {
                    b.HasOne("TeamHost.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeamHost.Domain.Entities.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamePlatform", b =>
                {
                    b.HasOne("TeamHost.Domain.Entities.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeamHost.Domain.Entities.Platform", null)
                        .WithMany()
                        .HasForeignKey("PlatformsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TeamHost.Domain.Entities.Developer", b =>
                {
                    b.HasOne("TeamHost.Domain.Entities.Country", "Country")
                        .WithMany("Developers")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("TeamHost.Domain.Entities.Game", b =>
                {
                    b.HasOne("TeamHost.Domain.Entities.Developer", "Developer")
                        .WithMany("Games")
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeamHost.Domain.Entities.MediaFile", "MainImage")
                        .WithOne("Game")
                        .HasForeignKey("TeamHost.Domain.Entities.Game", "MainImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");

                    b.Navigation("MainImage");
                });

            modelBuilder.Entity("TeamHost.Domain.Entities.MediaFile", b =>
                {
                    b.HasOne("TeamHost.Domain.Entities.Game", null)
                        .WithMany("MediaFiles")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("TeamHost.Domain.Entities.Platform", b =>
                {
                    b.HasOne("TeamHost.Domain.Entities.MediaFile", "MediaFile")
                        .WithMany()
                        .HasForeignKey("MediaFileId");

                    b.Navigation("MediaFile");
                });

            modelBuilder.Entity("TeamHost.Domain.Entities.Country", b =>
                {
                    b.Navigation("Developers");
                });

            modelBuilder.Entity("TeamHost.Domain.Entities.Developer", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("TeamHost.Domain.Entities.Game", b =>
                {
                    b.Navigation("MediaFiles");
                });

            modelBuilder.Entity("TeamHost.Domain.Entities.MediaFile", b =>
                {
                    b.Navigation("Game");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using AppB2C2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppB2C2.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppB2C2.Models.Collection", b =>
                {
                    b.Property<int>("CollectionId")
                        .HasColumnType("int");

                    b.Property<int?>("AddedItems")
                        .HasColumnType("int");

                    b.Property<string>("CollectionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CollectionItemItemId")
                        .HasColumnType("int");

                    b.Property<string>("CollectionName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("CollectionId");

                    b.HasIndex("CollectionItemItemId");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("AppB2C2.Models.CollectionItem", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<float>("EstimatedPrice")
                        .HasColumnType("real");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ReleaseDate")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.ToTable("CollectionItems");
                });

            modelBuilder.Entity("AppB2C2.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<int>("CreatedCollections")
                        .HasColumnType("int");

                    b.Property<string>("MailAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserPassword")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AppB2C2.Models.Collection", b =>
                {
                    b.HasOne("AppB2C2.Models.User", "User")
                        .WithMany("Collections")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AppB2C2.Models.CollectionItem", "CollectionItem")
                        .WithMany()
                        .HasForeignKey("CollectionItemItemId");

                    b.Navigation("CollectionItem");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AppB2C2.Models.CollectionItem", b =>
                {
                    b.HasOne("AppB2C2.Models.Collection", "Collection")
                        .WithMany("CollectionItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("AppB2C2.Models.Collection", b =>
                {
                    b.Navigation("CollectionItems");
                });

            modelBuilder.Entity("AppB2C2.Models.User", b =>
                {
                    b.Navigation("Collections");
                });
#pragma warning restore 612, 618
        }
    }
}

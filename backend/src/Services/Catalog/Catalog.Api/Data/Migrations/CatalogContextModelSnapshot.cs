﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WhiteBear.Services.Catalog.Api.Data.Context;
using WhiteBear.Services.Catalog.Api.Enums;

namespace WhiteBear.Services.Catalog.Api.Data.Migrations
{
    [DbContext(typeof(CatalogContext))]
    partial class CatalogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WhiteBear.Services.Catalog.Api.Data.Entities.Bottle", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Capacity");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<double>("Price");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Bottles");
                });

            modelBuilder.Entity("WhiteBear.Services.Catalog.Api.Data.Entities.Brand", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("WhiteBear.Services.Catalog.Api.Data.Entities.Category", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("WhiteBear.Services.Catalog.Api.Data.Entities.Image", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("URL");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("WhiteBear.Services.Catalog.Api.Data.Entities.Product", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BeerType");

                    b.Property<string>("BrandId");

                    b.Property<string>("CategoryId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<double>("Density");

                    b.Property<string>("Description");

                    b.Property<double?>("Discount");

                    b.Property<string>("ImageId");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ImageId");

                    b.ToTable("ProductItems");
                });

            modelBuilder.Entity("WhiteBear.Services.Catalog.Api.Data.Entities.Reaction", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("ProductId");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("WhiteBear.Services.Catalog.Api.Data.Entities.Brand", b =>
                {
                    b.HasOne("WhiteBear.Services.Catalog.Api.Data.Entities.Category", "Category")
                        .WithMany("Brands")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WhiteBear.Services.Catalog.Api.Data.Entities.Product", b =>
                {
                    b.HasOne("WhiteBear.Services.Catalog.Api.Data.Entities.Brand", "Brand")
                        .WithMany("ProductItems")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WhiteBear.Services.Catalog.Api.Data.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WhiteBear.Services.Catalog.Api.Data.Entities.Image", "PreviewImg")
                        .WithMany()
                        .HasForeignKey("ImageId");
                });

            modelBuilder.Entity("WhiteBear.Services.Catalog.Api.Data.Entities.Reaction", b =>
                {
                    b.HasOne("WhiteBear.Services.Catalog.Api.Data.Entities.Product", "Product")
                        .WithMany("Reactions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}

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

            modelBuilder.Entity("WhiteBear.Services.Catalog.Api.Data.Entities.Brand", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryId")
                        .IsRequired();

                    b.Property<string>("CategoryId1");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("ProductItemId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CategoryId1");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("WhiteBear.Services.Catalog.Api.Data.Entities.Category", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrandId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("ProductItemId");

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

                    b.Property<string>("BrandId")
                        .IsRequired();

                    b.Property<string>("BrandId1");

                    b.Property<string>("CategoryId")
                        .IsRequired();

                    b.Property<string>("CategoryId1");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<double>("Density");

                    b.Property<string>("Description");

                    b.Property<double?>("Discount");

                    b.Property<string>("ImageId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.Property<string>("ReactionId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("BrandId1");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CategoryId1");

                    b.HasIndex("ImageId");

                    b.ToTable("ProductItems");
                });

            modelBuilder.Entity("WhiteBear.Services.Catalog.Api.Data.Entities.Reaction", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("ProductId");

                    b.Property<string>("ProductItemId")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductItemId");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("WhiteBear.Services.Catalog.Api.Data.Entities.Brand", b =>
                {
                    b.HasOne("WhiteBear.Services.Catalog.Api.Data.Entities.Category")
                        .WithMany("Brands")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WhiteBear.Services.Catalog.Api.Data.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId1")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WhiteBear.Services.Catalog.Api.Data.Entities.Product", b =>
                {
                    b.HasOne("WhiteBear.Services.Catalog.Api.Data.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WhiteBear.Services.Catalog.Api.Data.Entities.Brand")
                        .WithMany("ProductItems")
                        .HasForeignKey("BrandId1")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WhiteBear.Services.Catalog.Api.Data.Entities.Category")
                        .WithMany("ProductItems")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WhiteBear.Services.Catalog.Api.Data.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId1")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WhiteBear.Services.Catalog.Api.Data.Entities.Image", "PreviewImg")
                        .WithMany()
                        .HasForeignKey("ImageId");
                });

            modelBuilder.Entity("WhiteBear.Services.Catalog.Api.Data.Entities.Reaction", b =>
                {
                    b.HasOne("WhiteBear.Services.Catalog.Api.Data.Entities.Product")
                        .WithMany("Reactions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WhiteBear.Services.Catalog.Api.Data.Entities.Product", "ProductItem")
                        .WithMany()
                        .HasForeignKey("ProductItemId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}

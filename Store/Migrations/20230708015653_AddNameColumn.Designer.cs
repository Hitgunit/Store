﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store.Data;

#nullable disable

namespace Store.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230708015653_AddNameColumn")]
    partial class AddNameColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Store.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Tommy Hilfiger",
                            Description = "Bonita camisa azul",
                            Gender = 0,
                            Image = "https://cdn-images.farfetch-contents.com/16/96/57/69/16965769_34746140_1000.jpg",
                            Name = "Tommy Hilfiger A54",
                            ProductType = 1
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Lacoste",
                            Description = "Bonita playera rosa",
                            Gender = 1,
                            Image = "https://static.dafiti.com.br/p/Lacoste-Camiseta-Lacoste-Logo-Rosa-7688-3778407-1-zoom.jpg",
                            Name = "Lacoste SD34",
                            ProductType = 1
                        },
                        new
                        {
                            Id = 3,
                            Brand = "C&A",
                            Description = "Bonito pantalon de mezclilla",
                            Gender = 0,
                            Image = "https://th.bing.com/th/id/OIP.VZchNI-R6Ksx2sMqXlOJPwHaLH?pid=ImgDet&rs=1",
                            Name = "C&A Camoo Late",
                            ProductType = 0
                        },
                        new
                        {
                            Id = 4,
                            Brand = "CCP",
                            Description = "Bonito pantalon",
                            Gender = 1,
                            Image = "https://i5.walmartimages.com.mx/mg/gm/3pp/asr/43cfb29d-0aa0-4220-9274-ec037c06e9c0.944b2c78bafceaeb124c93f1236507c7.jpeg?odnHeight=612&odnWidth=612&odnBg=FFFFFF",
                            Name = "CCP Fashion",
                            ProductType = 0
                        },
                        new
                        {
                            Id = 5,
                            Brand = "Nike",
                            Description = "Bonita playera",
                            Gender = 0,
                            Image = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/b1a96003-8c49-41ab-9ec5-71dcafbdbeb1/playera-de-fitness-dri-fit-WlRvw8.png",
                            Name = "Nike Sport",
                            ProductType = 1
                        });
                });

            modelBuilder.Entity("Store.Models.ProductDetail", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("ProdcutId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdcutId");

                    b.ToTable("ProductDetails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Azul",
                            Material = "Algodon",
                            Price = 299.0,
                            ProdcutId = 1
                        },
                        new
                        {
                            Id = 2,
                            Color = "Rosa",
                            Material = "Poliester",
                            Price = 499.0,
                            ProdcutId = 2
                        },
                        new
                        {
                            Id = 3,
                            Color = "Azul",
                            Material = "Mezclilla",
                            Price = 199.0,
                            ProdcutId = 3
                        },
                        new
                        {
                            Id = 4,
                            Color = "Cafe",
                            Material = "Algodon",
                            Price = 499.0,
                            ProdcutId = 4
                        },
                        new
                        {
                            Id = 5,
                            Color = "Blanca",
                            Material = "Algodon",
                            Price = 499.0,
                            ProdcutId = 5
                        });
                });

            modelBuilder.Entity("Store.Models.Stock", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("ProductDetailId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductDetailId");

                    b.ToTable("Stocks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductDetailId = 1,
                            Quantity = 100,
                            Size = 2
                        },
                        new
                        {
                            Id = 2,
                            ProductDetailId = 2,
                            Quantity = 100,
                            Size = 1
                        },
                        new
                        {
                            Id = 3,
                            ProductDetailId = 3,
                            Quantity = 100,
                            Size = 3
                        },
                        new
                        {
                            Id = 4,
                            ProductDetailId = 4,
                            Quantity = 100,
                            Size = 0
                        },
                        new
                        {
                            Id = 5,
                            ProductDetailId = 5,
                            Quantity = 100,
                            Size = 1
                        });
                });

            modelBuilder.Entity("Store.Models.ProductDetail", b =>
                {
                    b.HasOne("Store.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProdcutId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Store.Models.Stock", b =>
                {
                    b.HasOne("Store.Models.ProductDetail", "ProductDetail")
                        .WithMany()
                        .HasForeignKey("ProductDetailId");

                    b.Navigation("ProductDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
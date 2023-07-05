using Microsoft.EntityFrameworkCore;
using Store.Data.Enum;
using Store.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Store.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Brand = "Tommy Hilfiger",
                    ProductType = Enum.ProductType.Shirt,
                    Gender = Enum.Gender.Man,
                    Description = "Bonita camisa azul",
                    Image = "https://cdn-images.farfetch-contents.com/16/96/57/69/16965769_34746140_1000.jpg"
                },
                new Product
                {
                    Id = 2,
                    Brand = "Lacoste",
                    ProductType = Enum.ProductType.Shirt,
                    Gender = Enum.Gender.Female,
                    Description = "Bonita playera rosa",
                    Image = "https://static.dafiti.com.br/p/Lacoste-Camiseta-Lacoste-Logo-Rosa-7688-3778407-1-zoom.jpg"
                }, 
                new Product
                {
                    Id = 3,
                    Brand = "C&A",
                    ProductType = Enum.ProductType.Pant,
                    Gender = Enum.Gender.Man,
                    Description = "Bonito pantalon de mezclilla",
                    Image = "https://th.bing.com/th/id/OIP.VZchNI-R6Ksx2sMqXlOJPwHaLH?pid=ImgDet&rs=1"
                }
                );
            builder.Entity<ProductDetail>().HasData(
                new ProductDetail
                {
                    Id = 1,
                    ProdcutId = 1,
                    Material = "Algodon",
                    Color = "Azul"
                },
                new ProductDetail
                {
                    Id = 2,
                    ProdcutId = 2,
                    Material = "Poliester",
                    Color = "Rosa"
                },
                new ProductDetail
                {
                    Id = 3,
                    ProdcutId = 3,
                    Material = "Mezclilla",
                    Color = "Azul"
                }
                );
            builder.Entity<Price>().HasData(
                new Price
                {
                    Id = 1,
                    ProductId = 1,
                    Prices = 200,
                    StartDate = DateTime.Now

                },
                new Price
                {
                    Id = 2,
                    ProductId = 2,
                    Prices = 400,
                    StartDate = DateTime.Now

                },
                new Price
                {
                    Id = 3,
                    ProductId = 3,
                    Prices = 150.99,
                    StartDate = DateTime.Now

                }
                );
            builder.Entity<Stock>().HasData(
                new Stock
                {
                    Id= 1,
                    ProductDetailId = 1,
                    Size = Size.Large,
                    Quantity = 100,
                },
                new Stock
                {
                    Id = 2,
                    ProductDetailId = 2,
                    Size = Size.Medium,
                    Quantity = 100,
                },
                new Stock
                {
                    Id = 3,
                    ProductDetailId = 3,
                    Size = Size.XtraLarge,
                    Quantity = 100,
                }
                );
        }
    }
}

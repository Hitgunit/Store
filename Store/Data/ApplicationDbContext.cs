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
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Tommy Hilfiger A54",
                    Brand = "Tommy Hilfiger",
                    ProductType = Enum.ProductType.Shirt,
                    Gender = Enum.Gender.Man,
                    Description = "Bonita camisa azul",
                    Image = "https://cdn-images.farfetch-contents.com/16/96/57/69/16965769_34746140_1000.jpg"
                },
                new Product
                {
                    Id = 2,
                    Name = "Lacoste SD34",
                    Brand = "Lacoste",
                    ProductType = Enum.ProductType.Shirt,
                    Gender = Enum.Gender.Female,
                    Description = "Bonita playera rosa",
                    Image = "https://static.dafiti.com.br/p/Lacoste-Camiseta-Lacoste-Logo-Rosa-7688-3778407-1-zoom.jpg"
                }, 
                new Product
                {
                    Id = 3,
                    Name = "C&A Camoo Late",
                    Brand = "C&A",
                    ProductType = Enum.ProductType.Pant,
                    Gender = Enum.Gender.Man,
                    Description = "Bonito pantalon de mezclilla",
                    Image = "https://th.bing.com/th/id/OIP.VZchNI-R6Ksx2sMqXlOJPwHaLH?pid=ImgDet&rs=1"
                },
                new Product
                {
                    Id = 4,
                    Name = "CCP Fashion",
                    Brand = "CCP",
                    ProductType = Enum.ProductType.Pant,
                    Gender = Enum.Gender.Female,
                    Description = "Bonito pantalon",
                    Image = "https://i5.walmartimages.com.mx/mg/gm/3pp/asr/43cfb29d-0aa0-4220-9274-ec037c06e9c0.944b2c78bafceaeb124c93f1236507c7.jpeg?odnHeight=612&odnWidth=612&odnBg=FFFFFF"
                },
                new Product
                {
                    Id = 5,
                    Name = "Nike Sport",
                    Brand = "Nike",
                    ProductType = Enum.ProductType.Shirt,
                    Gender = Enum.Gender.Man,
                    Description = "Bonita playera",
                    Image = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/b1a96003-8c49-41ab-9ec5-71dcafbdbeb1/playera-de-fitness-dri-fit-WlRvw8.png"
                }
                );
            builder.Entity<ProductDetail>().HasData(
                new ProductDetail
                {
                    Id = 1,
                    ProdcutId = 1,
                    Material = "Algodon",
                    Color = "Azul",
                    Price = 299
                },
                new ProductDetail
                {
                    Id = 2,
                    ProdcutId = 2,
                    Material = "Poliester",
                    Color = "Rosa",
                    Price = 499
                },
                new ProductDetail
                {
                    Id = 3,
                    ProdcutId = 3,
                    Material = "Mezclilla",
                    Color = "Azul",
                    Price = 199
                },
                new ProductDetail
                {
                    Id = 4,
                    ProdcutId = 4,
                    Material = "Algodon",
                    Color = "Cafe",
                    Price = 499
                },
                new ProductDetail
                {
                    Id = 5,
                    ProdcutId = 5,
                    Material = "Algodon",
                    Color = "Blanca",
                    Price = 499
                }
                ); ;
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
                },
                new Stock
                {
                    Id = 4,
                    ProductDetailId = 4,
                    Size = Size.Small,
                    Quantity = 100,
                },
                new Stock
                {
                    Id = 5,
                    ProductDetailId = 5,
                    Size = Size.Medium,
                    Quantity = 100,
                }
                );
        }
    }
}

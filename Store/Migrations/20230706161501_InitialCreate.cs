using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductType = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Prices = table.Column<double>(type: "float", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prices_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdcutId = table.Column<int>(type: "int", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products_ProdcutId",
                        column: x => x.ProdcutId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductDetailId = table.Column<int>(type: "int", nullable: true),
                    Size = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_ProductDetails_ProductDetailId",
                        column: x => x.ProductDetailId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Description", "Gender", "Image", "ProductType" },
                values: new object[,]
                {
                    { 1, "Tommy Hilfiger", "Bonita camisa azul", 0, "https://cdn-images.farfetch-contents.com/16/96/57/69/16965769_34746140_1000.jpg", 1 },
                    { 2, "Lacoste", "Bonita playera rosa", 1, "https://static.dafiti.com.br/p/Lacoste-Camiseta-Lacoste-Logo-Rosa-7688-3778407-1-zoom.jpg", 1 },
                    { 3, "C&A", "Bonito pantalon de mezclilla", 0, "https://th.bing.com/th/id/OIP.VZchNI-R6Ksx2sMqXlOJPwHaLH?pid=ImgDet&rs=1", 0 }
                });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "FinishDate", "Prices", "ProductId", "StartDate" },
                values: new object[,]
                {
                    { 1, null, 200.0, 1, new DateTime(2023, 7, 6, 10, 15, 1, 159, DateTimeKind.Local).AddTicks(5313) },
                    { 2, null, 400.0, 2, new DateTime(2023, 7, 6, 10, 15, 1, 159, DateTimeKind.Local).AddTicks(5327) },
                    { 3, null, 150.99000000000001, 3, new DateTime(2023, 7, 6, 10, 15, 1, 159, DateTimeKind.Local).AddTicks(5328) }
                });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "Color", "Material", "ProdcutId" },
                values: new object[,]
                {
                    { 1, "Azul", "Algodon", 1 },
                    { 2, "Rosa", "Poliester", 2 },
                    { 3, "Azul", "Mezclilla", 3 }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "ProductDetailId", "Quantity", "Size" },
                values: new object[,]
                {
                    { 1, 1, 100, 2 },
                    { 2, 2, 100, 1 },
                    { 3, 3, 100, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prices_ProductId",
                table: "Prices",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProdcutId",
                table: "ProductDetails",
                column: "ProdcutId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductDetailId",
                table: "Stocks",
                column: "ProductDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

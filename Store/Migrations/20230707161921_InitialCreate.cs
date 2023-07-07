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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "ProductDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdcutId = table.Column<int>(type: "int", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true)
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
                columns: new[] { "Id", "Brand", "Description", "Gender", "Image", "Name", "ProductType" },
                values: new object[,]
                {
                    { 1, "Tommy Hilfiger", "Bonita camisa azul", 0, "https://cdn-images.farfetch-contents.com/16/96/57/69/16965769_34746140_1000.jpg", null, 1 },
                    { 2, "Lacoste", "Bonita playera rosa", 1, "https://static.dafiti.com.br/p/Lacoste-Camiseta-Lacoste-Logo-Rosa-7688-3778407-1-zoom.jpg", null, 1 },
                    { 3, "C&A", "Bonito pantalon de mezclilla", 0, "https://th.bing.com/th/id/OIP.VZchNI-R6Ksx2sMqXlOJPwHaLH?pid=ImgDet&rs=1", null, 0 },
                    { 4, "CCP", "Bonito pantalon", 1, "https://i5.walmartimages.com.mx/mg/gm/3pp/asr/43cfb29d-0aa0-4220-9274-ec037c06e9c0.944b2c78bafceaeb124c93f1236507c7.jpeg?odnHeight=612&odnWidth=612&odnBg=FFFFFF", null, 0 },
                    { 5, "Nike", "Bonita playera", 0, "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/b1a96003-8c49-41ab-9ec5-71dcafbdbeb1/playera-de-fitness-dri-fit-WlRvw8.png", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "Color", "Material", "Price", "ProdcutId" },
                values: new object[,]
                {
                    { 1, "Azul", "Algodon", 299.0, 1 },
                    { 2, "Rosa", "Poliester", 499.0, 2 },
                    { 3, "Azul", "Mezclilla", 199.0, 3 },
                    { 4, "Cafe", "Algodon", 499.0, 4 },
                    { 5, "Blanca", "Algodon", 499.0, 5 }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "ProductDetailId", "Quantity", "Size" },
                values: new object[,]
                {
                    { 1, 1, 100, 2 },
                    { 2, 2, 100, 1 },
                    { 3, 3, 100, 3 },
                    { 4, 4, 100, 0 },
                    { 5, 5, 100, 1 }
                });

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
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

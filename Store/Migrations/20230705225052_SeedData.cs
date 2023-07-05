using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "brand",
                table: "Products",
                newName: "Brand");

            migrationBuilder.AlterColumn<int>(
                name: "Size",
                table: "Stocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Description", "Gender", "Image", "ProductType" },
                values: new object[,]
                {
                    { 1, "Tommy Hillfiguer", "Bonita camisa azul", 0, "https://cdn-images.farfetch-contents.com/16/96/57/69/16965769_34746140_1000.jpg", 1 },
                    { 2, "Lacoste", "Bonita playera rosa", 1, "https://static.dafiti.com.br/p/Lacoste-Camiseta-Lacoste-Logo-Rosa-7688-3778407-1-zoom.jpg", 1 },
                    { 3, "C&A", "Bonito pantalon de mezclilla", 0, "https://th.bing.com/th/id/OIP.VZchNI-R6Ksx2sMqXlOJPwHaLH?pid=ImgDet&rs=1", 0 }
                });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "FinishDate", "Prices", "ProductId", "StartDate" },
                values: new object[,]
                {
                    { 1, null, 200.0, 1, new DateTime(2023, 7, 5, 16, 50, 52, 832, DateTimeKind.Local).AddTicks(3531) },
                    { 2, null, 400.0, 2, new DateTime(2023, 7, 5, 16, 50, 52, 832, DateTimeKind.Local).AddTicks(3544) },
                    { 3, null, 150.99000000000001, 3, new DateTime(2023, 7, 5, 16, 50, 52, 832, DateTimeKind.Local).AddTicks(3545) }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "Products",
                newName: "brand");

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "Stocks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}

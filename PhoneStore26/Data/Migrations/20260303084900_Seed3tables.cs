using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PhoneStore26.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed3tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Smartphone" },
                    { 2, "Buttonphone" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "iPhone" },
                    { 2, "Samsung" }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "CategoryId", "Description", "ManufacturerId", "Price", "Series" },
                values: new object[,]
                {
                    { 1, 1, "low cost phone", 2, 155.0, "A25" },
                    { 2, 1, "cool phone", 2, 255.0, "A35" },
                    { 3, 1, "best phone", 1, 300.0, "15" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Manufacturer",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

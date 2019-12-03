using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehousely.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Count", "ImageString", "Name", "Price", "Size" },
                values: new object[] { 1, 5, "NoString", "FirstWine", 10.88m, "1L" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

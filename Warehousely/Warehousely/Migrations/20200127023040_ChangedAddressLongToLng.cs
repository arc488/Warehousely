using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehousely.Migrations
{
    public partial class ChangedAddressLongToLng : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Long",
                table: "Addresses");

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "Addresses",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lng",
                table: "Addresses");

            migrationBuilder.AddColumn<double>(
                name: "Long",
                table: "Addresses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}

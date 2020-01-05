using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehousely.Migrations
{
    public partial class ChangedSizeIdName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sizes_SizeId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Sizes");

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "Sizes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes",
                column: "SizeId");

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeId", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name" },
                values: new object[] { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "375 ml Demi" });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeId", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name" },
                values: new object[] { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "750 ml Standard" });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeId", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name" },
                values: new object[] { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "1.5 L Magnum" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sizes_SizeId",
                table: "Products",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "SizeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sizes_SizeId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes");

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "Sizes");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Sizes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name" },
                values: new object[] { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "375 ml Demi" });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name" },
                values: new object[] { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "750 ml Standard" });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name" },
                values: new object[] { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "1.5 L Magnum" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sizes_SizeId",
                table: "Products",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehousely.Migrations
{
    public partial class CreatedByModifiedByAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CratedById",
                table: "Sizes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "Sizes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CratedById",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CratedById",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CratedById",
                table: "ImageFiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "ImageFiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CratedById",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CratedById",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "Addresses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_CratedById",
                table: "Sizes",
                column: "CratedById");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_ModifiedById",
                table: "Sizes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CratedById",
                table: "Products",
                column: "CratedById");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ModifiedById",
                table: "Products",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CratedById",
                table: "Orders",
                column: "CratedById");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ModifiedById",
                table: "Orders",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFiles_CratedById",
                table: "ImageFiles",
                column: "CratedById");

            migrationBuilder.CreateIndex(
                name: "IX_ImageFiles_ModifiedById",
                table: "ImageFiles",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CratedById",
                table: "Customers",
                column: "CratedById");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ModifiedById",
                table: "Customers",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CratedById",
                table: "Addresses",
                column: "CratedById");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ModifiedById",
                table: "Addresses",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_CratedById",
                table: "Addresses",
                column: "CratedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_ModifiedById",
                table: "Addresses",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_CratedById",
                table: "Customers",
                column: "CratedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_ModifiedById",
                table: "Customers",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageFiles_AspNetUsers_CratedById",
                table: "ImageFiles",
                column: "CratedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageFiles_AspNetUsers_ModifiedById",
                table: "ImageFiles",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CratedById",
                table: "Orders",
                column: "CratedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ModifiedById",
                table: "Orders",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_CratedById",
                table: "Products",
                column: "CratedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_ModifiedById",
                table: "Products",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_AspNetUsers_CratedById",
                table: "Sizes",
                column: "CratedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_AspNetUsers_ModifiedById",
                table: "Sizes",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_CratedById",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_ModifiedById",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_CratedById",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_ModifiedById",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageFiles_AspNetUsers_CratedById",
                table: "ImageFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageFiles_AspNetUsers_ModifiedById",
                table: "ImageFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CratedById",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ModifiedById",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_CratedById",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_ModifiedById",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_AspNetUsers_CratedById",
                table: "Sizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_AspNetUsers_ModifiedById",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_CratedById",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_ModifiedById",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Products_CratedById",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ModifiedById",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CratedById",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ModifiedById",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_ImageFiles_CratedById",
                table: "ImageFiles");

            migrationBuilder.DropIndex(
                name: "IX_ImageFiles_ModifiedById",
                table: "ImageFiles");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CratedById",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ModifiedById",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CratedById",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_ModifiedById",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CratedById",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "CratedById",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CratedById",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CratedById",
                table: "ImageFiles");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "ImageFiles");

            migrationBuilder.DropColumn(
                name: "CratedById",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CratedById",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Addresses");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreASP.Migrations.SiteDB
{
    public partial class M012 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CartItems_ItemId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ItemId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "CartItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ItemId",
                table: "CartItems",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ItemId",
                table: "CartItems",
                column: "ItemId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ItemId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ItemId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "CartItems");

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ItemId",
                table: "Products",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CartItems_ItemId",
                table: "Products",
                column: "ItemId",
                principalTable: "CartItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreASP.Migrations.SiteDB
{
    public partial class M011 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Carts_CartId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_CartId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "User");

            migrationBuilder.AddColumn<Guid>(
                name: "CartHolderId",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CartHolderId",
                table: "Carts",
                column: "CartHolderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_User_CartHolderId",
                table: "Carts",
                column: "CartHolderId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_User_CartHolderId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_CartHolderId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CartHolderId",
                table: "Carts");

            migrationBuilder.AddColumn<Guid>(
                name: "CartId",
                table: "User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_CartId",
                table: "User",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Carts_CartId",
                table: "User",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

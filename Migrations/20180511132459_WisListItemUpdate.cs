using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCave.Migrations
{
    public partial class WisListItemUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "WishListItemTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "WishListItemTable",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "WishListItemTable",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "WishListItemTable");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "WishListItemTable");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "WishListItemTable");
        }
    }
}

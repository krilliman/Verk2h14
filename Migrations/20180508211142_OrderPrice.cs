using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCave.Migrations
{
    public partial class OrderPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CartItemTable",
                newName: "OrderId");

            migrationBuilder.AddColumn<double>(
                name: "OrderPrice",
                table: "OrderTable",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderPrice",
                table: "OrderTable");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "CartItemTable",
                newName: "UserId");
        }
    }
}

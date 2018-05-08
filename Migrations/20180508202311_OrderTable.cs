using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCave.Migrations
{
    public partial class OrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrderItemTable");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CategoryTable",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "SubcategoryID",
                table: "BookTable",
                newName: "SubCategoryID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BookTable",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "SubCategoryTable",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SubCategoryTable",
                newName: "ID");

            migrationBuilder.CreateTable(
                name: "OrderTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTable", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderTable");

            migrationBuilder.DropColumn(
                name: "MainCategoryID",
                table: "BookTable");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CategoryTable",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SubCategoryID",
                table: "BookTable",
                newName: "SubcategoryID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "BookTable",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "SubCategoryTable",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SubCategoryTable",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "OrderItemTable",
                nullable: false,
                defaultValue: 0);
        }
    }
}

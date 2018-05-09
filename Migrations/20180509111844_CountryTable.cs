using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCave.Migrations
{
    public partial class CountryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProfileImage",
                table: "UserInformationTable",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FavBook",
                table: "UserInformationTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserInformationTable",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "BookTable",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CopiesSold",
                table: "BookTable",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "AddressTable",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AddressTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "AddressTable",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CountryTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTable", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryTable");

            migrationBuilder.DropColumn(
                name: "FavBook",
                table: "UserInformationTable");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserInformationTable");

            migrationBuilder.DropColumn(
                name: "CopiesSold",
                table: "BookTable");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AddressTable");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "AddressTable");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ProfileImage",
                table: "UserInformationTable",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "BookTable",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PostalCode",
                table: "AddressTable",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

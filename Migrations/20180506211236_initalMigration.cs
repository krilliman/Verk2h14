using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCave.Migrations
{
    public partial class initalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Country = table.Column<string>(nullable: true),
                    PostalCode = table.Column<int>(nullable: false),
                    StreetLine = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    Isbn = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    PublisherId = table.Column<int>(nullable: false),
                    Rating = table.Column<double>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    SubcategoryID = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    Views = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardInformationTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardHolder = table.Column<string>(nullable: true),
                    CardNumber = table.Column<string>(nullable: true),
                    ExpireMonth = table.Column<int>(nullable: false),
                    ExpireYear = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardInformationTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartItemTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItemTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PublisherTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublisherTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RatingTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Rate = table.Column<double>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoryTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoryTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInformationTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ProfileImage = table.Column<byte[]>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInformationTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WishListItemTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishListItemTable", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressTable");

            migrationBuilder.DropTable(
                name: "AuthorTable");

            migrationBuilder.DropTable(
                name: "BookTable");

            migrationBuilder.DropTable(
                name: "CardInformationTable");

            migrationBuilder.DropTable(
                name: "CartItemTable");

            migrationBuilder.DropTable(
                name: "CategoryTable");

            migrationBuilder.DropTable(
                name: "OrderItemTable");

            migrationBuilder.DropTable(
                name: "PublisherTable");

            migrationBuilder.DropTable(
                name: "RatingTable");

            migrationBuilder.DropTable(
                name: "SubCategoryTable");

            migrationBuilder.DropTable(
                name: "UserInformationTable");

            migrationBuilder.DropTable(
                name: "WishListItemTable");
        }
    }
}

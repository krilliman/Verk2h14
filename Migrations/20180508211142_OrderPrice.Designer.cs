﻿// <auto-generated />
using BookCave.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BookCave.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180508211142_OrderPrice")]
    partial class OrderPrice
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookCave.Models.EntityModels.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country");

                    b.Property<int>("PostalCode");

                    b.Property<string>("StreetLine");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("AddressTable");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AuthorTable");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<string>("Description");

                    b.Property<byte[]>("Image");

                    b.Property<string>("Isbn");

                    b.Property<int>("MainCategoryID");

                    b.Property<string>("Name");

                    b.Property<DateTime>("PublishDate");

                    b.Property<int>("PublisherId");

                    b.Property<double>("Rating");

                    b.Property<int>("Stock");

                    b.Property<int>("SubCategoryID");

                    b.Property<double>("TotalPrice");

                    b.Property<int>("Views");

                    b.HasKey("ID");

                    b.ToTable("BookTable");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.CardInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CardHolder");

                    b.Property<string>("CardNumber");

                    b.Property<int>("ExpireMonth");

                    b.Property<int>("ExpireYear");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("CardInformationTable");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<int>("OrderId");

                    b.Property<double>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.ToTable("CartItemTable");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("CategoryTable");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("OrderPrice");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("OrderTable");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<int>("OrderId");

                    b.Property<double>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.ToTable("OrderItemTable");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PublisherTable");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<string>("Comment");

                    b.Property<double>("Rate");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("RatingTable");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.SubCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryID");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("SubCategoryTable");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.UserInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<byte[]>("ProfileImage");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("UserInformationTable");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.WishListItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("WishListItemTable");
                });
#pragma warning restore 612, 618
        }
    }
}

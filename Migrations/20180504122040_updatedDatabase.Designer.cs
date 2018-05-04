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
    [Migration("20180504122040_updatedDatabase")]
    partial class updatedDatabase
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

                    b.HasKey("Id");

                    b.ToTable("AddressTable");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.AddressBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("Address3");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("AddressBookTable");
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<string>("Description");

                    b.Property<int>("Isbn");

                    b.Property<string>("Name");

                    b.Property<DateTime>("PublishDate");

                    b.Property<double>("Rating");

                    b.Property<int>("Stock");

                    b.Property<int>("SubcategoryID");

                    b.Property<double>("TotalPrice");

                    b.Property<int>("Views");

                    b.HasKey("Id");

                    b.ToTable("BookTable");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.CardInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CardHolder");

                    b.Property<string>("CardNumber");

                    b.Property<int>("Cvc");

                    b.Property<int>("ExpireMonth");

                    b.Property<int>("ExpireYear");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("CardInformationTable");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("CartTable");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<int>("CartId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.ToTable("CartItemTable");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("CategoryTable");
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

            modelBuilder.Entity("BookCave.Models.EntityModels.SubCatagory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SubCategoryTable");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.WishList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("WishList");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.WishListItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<int>("WishListId");

                    b.HasKey("Id");

                    b.ToTable("WishListItemTable");
                });
#pragma warning restore 612, 618
        }
    }
}

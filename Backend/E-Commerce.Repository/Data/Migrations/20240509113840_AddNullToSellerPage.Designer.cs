﻿// <auto-generated />
using System;
using E_Commerce.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_Commerce.Repository.Data.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20240509113840_AddNullToSellerPage")]
    partial class AddNullToSellerPage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CartProduct", b =>
                {
                    b.Property<int>("CartsId")
                        .HasColumnType("int");

                    b.Property<int>("productsid")
                        .HasColumnType("int");

                    b.HasKey("CartsId", "productsid");

                    b.HasIndex("productsid");

                    b.ToTable("CartProduct");
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("cart");
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.Coulor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("colour_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hex_value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("colors");
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.Identity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("cartId")
                        .HasColumnType("int");

                    b.Property<DateTime>("orderDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("cartId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("Orderitems");
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.Page", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("SellerId")
                        .IsUnique();

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.Payment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("orderId")
                        .HasColumnType("int");

                    b.Property<int>("paymentMethod")
                        .HasColumnType("int");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("orderId");

                    b.HasIndex("userId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("NumOfProductInStock")
                        .HasColumnType("int");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.Property<string>("brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image_link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SellerId");

                    b.ToTable("products");
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("reviews");
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.Seller", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("IDImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<int?>("PageId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("sellers");
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.Tag", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("tags");
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.WishList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("userId")
                        .IsUnique();

                    b.ToTable("wishlist");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProductTag", b =>
                {
                    b.Property<int>("Productsid")
                        .HasColumnType("int");

                    b.Property<int>("tag_listid")
                        .HasColumnType("int");

                    b.HasKey("Productsid", "tag_listid");

                    b.HasIndex("tag_listid");

                    b.ToTable("ProductTag");
                });

            modelBuilder.Entity("ProductWishList", b =>
                {
                    b.Property<int>("WishListsId")
                        .HasColumnType("int");

                    b.Property<int>("productsid")
                        .HasColumnType("int");

                    b.HasKey("WishListsId", "productsid");

                    b.HasIndex("productsid");

                    b.ToTable("ProductWishList");
                });

            modelBuilder.Entity("CartProduct", b =>
                {
                    b.HasOne("E_Commerce.Core.Entities.Cart", null)
                        .WithMany()
                        .HasForeignKey("CartsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce.Core.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("productsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.Cart", b =>
                {
                    b.HasOne("E_Commerce.Core.Entities.Identity.AppUser", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.Coulor", b =>
                {
                    b.HasOne("E_Commerce.Core.Entities.Product", "Product")
                        .WithMany("Colors")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.Order", b =>
                {
                    b.HasOne("E_Commerce.Core.Entities.Identity.AppUser", "user")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce.Core.Entities.Cart", "cart")
                        .WithMany("order")
                        .HasForeignKey("cartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cart");

                    b.Navigation("user");
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.OrderItem", b =>
                {
                    b.HasOne("E_Commerce.Core.Entities.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce.Core.Entities.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.Page", b =>
                {
                    b.HasOne("E_Commerce.Core.Entities.Seller", "Seller")
                        .WithOne("Page")
                        .HasForeignKey("E_Commerce.Core.Entities.Page", "SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.Payment", b =>
                {
                    b.HasOne("E_Commerce.Core.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("orderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce.Core.Entities.Identity.AppUser", "User")
                        .WithMany("Payment")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("User");
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.Product", b =>
                {
                    b.HasOne("E_Commerce.Core.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("E_Commerce.Core.Entities.Seller", "seller")
                        .WithMany("ProductList")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("seller");
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.Review", b =>
                {
                    b.HasOne("E_Commerce.Core.Entities.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce.Core.Entities.Identity.AppUser", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.WishList", b =>
                {
                    b.HasOne("E_Commerce.Core.Entities.Identity.AppUser", "user")
                        .WithOne("WishList")
                        .HasForeignKey("E_Commerce.Core.Entities.WishList", "userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("E_Commerce.Core.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("E_Commerce.Core.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce.Core.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("E_Commerce.Core.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductTag", b =>
                {
                    b.HasOne("E_Commerce.Core.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("Productsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce.Core.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("tag_listid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductWishList", b =>
                {
                    b.HasOne("E_Commerce.Core.Entities.WishList", null)
                        .WithMany()
                        .HasForeignKey("WishListsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce.Core.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("productsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.Cart", b =>
                {
                    b.Navigation("order");
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.Identity.AppUser", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Payment");

                    b.Navigation("Reviews");

                    b.Navigation("WishList")
                        .IsRequired();
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.Product", b =>
                {
                    b.Navigation("Colors");

                    b.Navigation("OrderItems");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("E_Commerce.Core.Entities.Seller", b =>
                {
                    b.Navigation("Page")
                        .IsRequired();

                    b.Navigation("ProductList");
                });
#pragma warning restore 612, 618
        }
    }
}

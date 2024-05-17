using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrderModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_sellers_SellerId",
                table: "AspNetUsers");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Payments_Order_orderId",
            //    table: "Payments");

            //migrationBuilder.DropTable(
            //    name: "Orders");

            //migrationBuilder.DropTable(
            //    name: "ProductTag");

            //migrationBuilder.DropTable(
            //    name: "tags");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SellerId",
                table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "IsAccepted",
            //    table: "sellers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "sellers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "DeliveryMethods",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveryTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMethods", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryMethodid = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    //PaymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CartId = table.Column<int>(type: "int", nullable: true),
                    Productid = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_orders_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_orders_DeliveryMethods_DeliveryMethodid",
                        column: x => x.DeliveryMethodid,
                        principalTable: "DeliveryMethods",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_orders_cart_CartId",
                        column: x => x.CartId,
                        principalTable: "cart",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_orders_products_Productid",
                        column: x => x.Productid,
                        principalTable: "products",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Orderitems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_ProductId = table.Column<int>(type: "int", nullable: false),
                    Product_ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Orderid = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderitems", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orderitems_orders_Orderid",
                        column: x => x.Orderid,
                        principalTable: "orders",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_sellers_UserId",
                table: "sellers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orderitems_Orderid",
                table: "Orderitems",
                column: "Orderid");

            migrationBuilder.CreateIndex(
                name: "IX_orders_AppUserId",
                table: "orders",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_CartId",
                table: "orders",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_DeliveryMethodid",
                table: "orders",
                column: "DeliveryMethodid");

            migrationBuilder.CreateIndex(
                name: "IX_orders_Productid",
                table: "orders",
                column: "Productid");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Payments_orders_orderId",
            //    table: "Payments",
            //    column: "orderId",
            //    principalTable: "orders",
            //    principalColumn: "id",
            //    onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sellers_AspNetUsers_UserId",
                table: "sellers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_orders_orderId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_sellers_AspNetUsers_UserId",
                table: "sellers");

            migrationBuilder.DropTable(
                name: "Orderitems");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "DeliveryMethods");

            migrationBuilder.DropIndex(
                name: "IX_sellers_UserId",
                table: "sellers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "sellers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "sellers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    TempId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.UniqueConstraint("AK_Order_TempId", x => x.TempId);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTag",
                columns: table => new
                {
                    Productsid = table.Column<int>(type: "int", nullable: false),
                    tag_listid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTag", x => new { x.Productsid, x.tag_listid });
                    table.ForeignKey(
                        name: "FK_ProductTag_products_Productsid",
                        column: x => x.Productsid,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTag_tags_tag_listid",
                        column: x => x.tag_listid,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SellerId",
                table: "AspNetUsers",
                column: "SellerId",
                unique: true,
                filter: "[SellerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTag_tag_listid",
                table: "ProductTag",
                column: "tag_listid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_sellers_SellerId",
                table: "AspNetUsers",
                column: "SellerId",
                principalTable: "sellers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Order_orderId",
                table: "Payments",
                column: "orderId",
                principalTable: "Order",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

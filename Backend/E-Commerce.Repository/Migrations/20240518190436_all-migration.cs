using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Repository.Migrations
{
    /// <inheritdoc />
    public partial class allmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "brand",
                table: "products");

            migrationBuilder.DropColumn(
                name: "name",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Orderitems");

            migrationBuilder.DropColumn(
                name: "name",
                table: "DeliveryMethods");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "reviews",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "Brandsid",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "brandss",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brandss", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_Brandsid",
                table: "products",
                column: "Brandsid");

            migrationBuilder.AddForeignKey(
                name: "FK_products_brandss_Brandsid",
                table: "products",
                column: "Brandsid",
                principalTable: "brandss",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_brandss_Brandsid",
                table: "products");

            migrationBuilder.DropTable(
                name: "brandss");

            migrationBuilder.DropIndex(
                name: "IX_products_Brandsid",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Brandsid",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "reviews",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "brand",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Orderitems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "DeliveryMethods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

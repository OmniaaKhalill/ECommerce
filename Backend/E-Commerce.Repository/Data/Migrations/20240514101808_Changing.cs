using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class Changing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_brandss_Brandsid",
                table: "products");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "products");

            migrationBuilder.AlterColumn<int>(
                name: "Brandsid",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "Brandsid",
                table: "products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_products_brandss_Brandsid",
                table: "products",
                column: "Brandsid",
                principalTable: "brandss",
                principalColumn: "id");
        }
    }
}

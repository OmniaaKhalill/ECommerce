using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "brand",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "Brandsid",
                table: "products",
                type: "int",
                nullable: true);

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
                principalColumn: "id");
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
                name: "BrandId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Brandsid",
                table: "products");

            migrationBuilder.AddColumn<string>(
                name: "brand",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

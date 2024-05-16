using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class ss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_products_categories_CategoryId",
            //    table: "products");

            //migrationBuilder.RenameColumn(
            //    name: "Name",
            //    table: "sellers",
            //    newName: "name");

            //migrationBuilder.RenameColumn(
            //    name: "Id",
            //    table: "sellers",
            //    newName: "id");

            //migrationBuilder.AlterColumn<int>(
            //    name: "id",
            //    table: "sellers",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(450)")
            //    .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AlterColumn<int>(
            //    name: "SellerId",
            //    table: "products",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(450)");

            //migrationBuilder.AlterColumn<int>(
            //    name: "CategoryId",
            //    table: "products",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "SellerId",
            //    table: "Pages",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(450)");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_products_categories_CategoryId",
            //    table: "products",
            //    column: "CategoryId",
            //    principalTable: "categories",
            //    principalColumn: "id",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_products_categories_CategoryId",
            //    table: "products");

            //migrationBuilder.RenameColumn(
            //    name: "name",
            //    table: "sellers",
            //    newName: "Name");

            //migrationBuilder.RenameColumn(
            //    name: "id",
            //    table: "sellers",
            //    newName: "Id");

            //migrationBuilder.AlterColumn<string>(
            //    name: "Id",
            //    table: "sellers",
            //    type: "nvarchar(450)",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AlterColumn<string>(
            //    name: "SellerId",
            //    table: "products",
            //    type: "nvarchar(450)",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            //migrationBuilder.AlterColumn<int>(
            //    name: "CategoryId",
            //    table: "products",
            //    type: "int",
            //    nullable: true,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            //migrationBuilder.AlterColumn<string>(
            //    name: "SellerId",
            //    table: "Pages",
            //    type: "nvarchar(450)",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_products_categories_CategoryId",
            //    table: "products",
            //    column: "CategoryId",
            //    principalTable: "categories",
            //    principalColumn: "id");
        }
    }
}

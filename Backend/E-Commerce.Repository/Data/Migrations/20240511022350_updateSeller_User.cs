using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateSeller_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //   name: "UserId",
            //   table: "sellers",
            //   type: "nvarchar(max)",
            //   nullable: false,
            //   defaultValue: "");

            //migrationBuilder.AddColumn<int>(
            //    name: "SellerId",
            //    table: "AspNetUsers",
            //    type: "int",
            //    nullable: true,
            //    defaultValue: 0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUsers_SellerId",
            //    table: "AspNetUsers",
            //    column: "SellerId",
            //    unique: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AspNetUsers_sellers_SellerId",
            //    table: "AspNetUsers",
            //    column: "SellerId",
            //    principalTable: "sellers",
            //    principalColumn: "id",
            //    onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //   name: "FK_AspNetUsers_sellers_SellerId",
            //   table: "AspNetUsers");

            //migrationBuilder.DropIndex(
            //    name: "IX_AspNetUsers_SellerId",
            //    table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "UserId",
            //    table: "sellers");

            //migrationBuilder.DropColumn(
            //    name: "SellerId",
            //    table: "AspNetUsers");

        }
    }
}

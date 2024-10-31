using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaptopShop.Migrations
{
    /// <inheritdoc />
    public partial class db5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Laptops",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_UserId",
                table: "Laptops",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laptops_AspNetUsers_UserId",
                table: "Laptops",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laptops_AspNetUsers_UserId",
                table: "Laptops");

            migrationBuilder.DropIndex(
                name: "IX_Laptops_UserId",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Laptops");
        }
    }
}

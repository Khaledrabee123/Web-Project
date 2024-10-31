using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaptopShop.Migrations
{
    /// <inheritdoc />
    public partial class e1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "card_id",
                table: "Laptops",
                type: "int",
                nullable: false,
                defaultValue: 0);
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "card_id",
                table: "Laptops");
        }
    }
}

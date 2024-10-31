using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaptopShop.Migrations
{
    /// <inheritdoc />
    public partial class ads : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "groupname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "groupname",
                table: "AspNetUsers");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaptopShop.Migrations
{
    /// <inheritdoc />
    public partial class ee1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            
            migrationBuilder.AddColumn<int>(
                name: "Cart_id",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartLaptop",
                columns: table => new
                {
                    CartsId = table.Column<int>(type: "int", nullable: false),
                    laptopsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartLaptop", x => new { x.CartsId, x.laptopsId });
                    table.ForeignKey(
                        name: "FK_CartLaptop_Carts_CartsId",
                        column: x => x.CartsId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                
                });


            migrationBuilder.CreateIndex(
                name: "IX_CartLaptop_laptopsId",
                table: "CartLaptop",
                column: "laptopsId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Carts_Cart_id",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CartLaptop");

            migrationBuilder.DropTable(
                name: "Carts");



            migrationBuilder.DropColumn(
                name: "Cart_id",
                table: "AspNetUsers");



        }
    }
}

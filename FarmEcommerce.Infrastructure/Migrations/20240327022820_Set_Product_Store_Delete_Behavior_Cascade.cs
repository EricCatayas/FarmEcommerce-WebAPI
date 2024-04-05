using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmEcommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Set_Product_Store_Delete_Behavior_Cascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Stores_Store_Id",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Stores_Store_Id",
                table: "Products",
                column: "Store_Id",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Stores_Store_Id",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Stores_Store_Id",
                table: "Products",
                column: "Store_Id",
                principalTable: "Stores",
                principalColumn: "Id");
        }
    }
}

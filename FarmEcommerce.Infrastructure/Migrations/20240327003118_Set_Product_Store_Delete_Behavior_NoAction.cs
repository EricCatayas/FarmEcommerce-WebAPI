using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmEcommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Set_Product_Store_Delete_Behavior_NoAction : Migration
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
                principalColumn: "Id");
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
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

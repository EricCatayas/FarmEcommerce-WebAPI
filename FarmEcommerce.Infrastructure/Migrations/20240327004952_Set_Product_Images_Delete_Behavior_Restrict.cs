using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmEcommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Set_Product_Images_Delete_Behavior_Restrict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Images_Images_Id",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Images_Images_Id",
                table: "Products",
                column: "Images_Id",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Images_Images_Id",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Images_Images_Id",
                table: "Products",
                column: "Images_Id",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

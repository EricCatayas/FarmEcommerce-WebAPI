using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmEcommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fixed_Foreign_Key_Constraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_City_Id",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Images_Images_Id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Discounts_Discount_Id",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cities_City_Id",
                table: "Addresses",
                column: "City_Id",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Images_Images_Id",
                table: "AspNetUsers",
                column: "Images_Id",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Discounts_Discount_Id",
                table: "Products",
                column: "Discount_Id",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_City_Id",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Images_Images_Id",
                table: "AspNetUsers");
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Discounts_Discount_Id",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cities_City_Id",
                table: "Addresses",
                column: "City_Id",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Images_Images_Id",
                table: "AspNetUsers",
                column: "Images_Id",
                principalTable: "Images",
                principalColumn: "Id");
            migrationBuilder.AddForeignKey(
                name: "FK_Products_Discounts_Discount_Id",
                table: "Products",
                column: "Discount_Id",
                principalTable: "Discounts",
                principalColumn: "Id");
        }
    }
}

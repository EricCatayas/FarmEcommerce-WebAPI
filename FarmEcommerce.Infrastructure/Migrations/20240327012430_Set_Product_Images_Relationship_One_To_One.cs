using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmEcommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Set_Product_Images_Relationship_One_To_One : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Images_Id",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Images_Id",
                table: "Products",
                column: "Images_Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Images_Id",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Images_Id",
                table: "Products",
                column: "Images_Id");
        }
    }
}

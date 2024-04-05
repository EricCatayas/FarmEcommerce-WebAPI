using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmEcommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Removed_Image_Uploads_Images_One_To_Many_Redundancy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Uploads_Images_Images_Id",
                table: "Image_Uploads");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Uploads_Images_Images_Id",
                table: "Image_Uploads",
                column: "Images_Id",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Uploads_Images_Images_Id",
                table: "Image_Uploads");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Uploads_Images_Images_Id",
                table: "Image_Uploads",
                column: "Images_Id",
                principalTable: "Images",
                principalColumn: "Id");
        }
    }
}

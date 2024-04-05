using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmEcommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Set_Images_Image_Upload_Delete_Behavior_Cascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Uploads_Images_Images_Id",
                table: "Image_Uploads");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Images_Images_Id",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Uploads_Images_Images_Id",
                table: "Image_Uploads",
                column: "Images_Id",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Images_Images_Id",
                table: "Products",
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

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Images_Images_Id",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Uploads_Images_Images_Id",
                table: "Image_Uploads",
                column: "Images_Id",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Images_Images_Id",
                table: "Products",
                column: "Images_Id",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

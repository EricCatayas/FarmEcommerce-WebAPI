using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmEcommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Set_Image_Upload_Images_Delete_Behavior_NoAction : Migration
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
                onDelete: ReferentialAction.NoAction);
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
                principalColumn: "Id"
                );
        }
    }
}

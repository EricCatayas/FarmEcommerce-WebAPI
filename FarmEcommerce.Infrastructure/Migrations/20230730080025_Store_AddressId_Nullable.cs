using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmEcommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Store_AddressId_Nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Address_Id",
                table: "Stores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
            // Images config
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Images_ImagesId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ImagesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImagesId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Images_Id",
                table: "Products",
                column: "Images_Id");

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
            migrationBuilder.AlterColumn<int>(
                name: "Address_Id",
                table: "Stores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
            // Images config
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Images_Images_Id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Images_Id",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ImagesId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ImagesId",
                table: "Products",
                column: "ImagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Images_ImagesId",
                table: "Products",
                column: "ImagesId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}

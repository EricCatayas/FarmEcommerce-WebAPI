using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmEcommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationUser_FK_Store_Retry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Store_Id",
                table: "AspNetUsers",
                column: "Store_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Stores_Store_Id",
                table: "AspNetUsers",
                column: "Store_Id",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Stores_Store_Id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Store_Id",
                table: "AspNetUsers");

        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmEcommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Store_Address_Relationship_Configuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Stores_Address_Id",
                table: "Stores",
                column: "Address_Id",
                unique: true,
                filter: "[Address_Id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Addresses_Address_Id",
                table: "Stores",
                column: "Address_Id",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Addresses_Address_Id",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_Address_Id",
                table: "Stores");
        }
    }
}

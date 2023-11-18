using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmEcommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Store_Address_Id_Removed_Nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.DropIndex(
                name: "IX_Stores_Address_Id",
                table: "Stores");

            migrationBuilder.AlterColumn<int>(
                name: "Address_Id",
                table: "Stores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_Address_Id",
                table: "Stores",
                column: "Address_Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stores_Address_Id",
                table: "Stores");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_Address_Id",
                table: "Stores",
                column: "Address_Id",
                unique: true,
                filter: "[Address_Id] IS NOT NULL");
        }
    }
}

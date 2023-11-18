using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmEcommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Address_Removed_Province_Reference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Provinces_Province_Id",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_Province_Id",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Province_Id",
                table: "Addresses");

            migrationBuilder.CreateIndex(
                name: "IX_Municipalities_Province_Id",
                table: "Municipalities",
                column: "Province_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipalities_Provinces_Province_Id",
                table: "Municipalities",
                column: "Province_Id",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Municipalities_Provinces_Province_Id",
                table: "Municipalities");

            migrationBuilder.DropIndex(
                name: "IX_Municipalities_Province_Id",
                table: "Municipalities");

            migrationBuilder.AlterColumn<int>(
                name: "Address_Id",
                table: "Stores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Province_Id",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);            

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_Province_Id",
                table: "Addresses",
                column: "Province_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Provinces_Province_Id",
                table: "Addresses",
                column: "Province_Id",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

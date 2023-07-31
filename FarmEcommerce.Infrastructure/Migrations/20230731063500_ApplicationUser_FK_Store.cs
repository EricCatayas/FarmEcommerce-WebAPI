using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmEcommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationUser_FK_Store : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Owner_Id",
                table: "Stores",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Stores_Owner_Id",
                table: "Stores",
                column: "Owner_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_AspNetUsers_Owner_Id",
                table: "Stores",
                column: "Owner_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_AspNetUsers_Owner_Id",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_Owner_Id",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Owner_Id",
                table: "Stores");
        }
    }
}

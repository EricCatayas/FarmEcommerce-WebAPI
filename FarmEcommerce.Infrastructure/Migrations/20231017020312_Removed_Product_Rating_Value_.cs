using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmEcommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Removed_Product_Rating_Value_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating_Value",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Orders");

            migrationBuilder.AddColumn<Guid>(
                name: "User_Guid",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating_Value",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "User_Id",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.DropColumn(
               name: "User_Id",
               table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

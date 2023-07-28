using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmEcommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Removed_OnDeleteCascade_ProductCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_Product_Categories_Parent_Category_Id",
                table: "Product_Categories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Upload_Date",
                table: "Image_Uploads",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 27, 16, 17, 57, 227, DateTimeKind.Local).AddTicks(7594),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 27, 15, 57, 55, 572, DateTimeKind.Local).AddTicks(4207));

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categories_Product_Categories_Parent_Category_Id",
                table: "Product_Categories",
                column: "Parent_Category_Id",
                principalTable: "Product_Categories",
                principalColumn: "Id",
                onDelete:ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_Product_Categories_Parent_Category_Id",
                table: "Product_Categories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Upload_Date",
                table: "Image_Uploads",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 27, 15, 57, 55, 572, DateTimeKind.Local).AddTicks(4207),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 27, 16, 17, 57, 227, DateTimeKind.Local).AddTicks(7594));

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categories_Product_Categories_Parent_Category_Id",
                table: "Product_Categories",
                column: "Parent_Category_Id",
                principalTable: "Product_Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}

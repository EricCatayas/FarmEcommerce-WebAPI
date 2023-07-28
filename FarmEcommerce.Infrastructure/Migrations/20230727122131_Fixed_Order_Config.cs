using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmEcommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fixed_Order_Config : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Uploads_Images_Images_Id",
                table: "Image_Uploads");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Lines_Orders_OrderId",
                table: "Order_Lines");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_Shipping_Address_Id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Order_Status_Order_Status_Id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shipping_Methods_Shipping_Method_Id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_User_Payment_Methods_Payment_Method_Id",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Order_Lines_OrderId",
                table: "Order_Lines");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Order_Lines");

            //
            migrationBuilder.AlterColumn<int>(
               name: "Shipping_Address_Id",
               table: "Orders",
               type: "int",
               nullable: true,
               defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
               name: "Order_Status_Id",
               table: "Orders",
               type: "int",
               nullable: true,
               defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
               name: "Shipping_Method_Id",
               table: "Orders",
               type: "int",
               nullable: true,
               defaultValue: 0);
            migrationBuilder.AlterColumn<int>(
               name: "Payment_Method_Id",
               table: "Orders",
               type: "int",
               nullable: true,
               defaultValue: 0);
            //
            migrationBuilder.CreateIndex(
                name: "IX_Order_Lines_Order_Id",
                table: "Order_Lines",
                column: "Order_Id");
            migrationBuilder.AddForeignKey(
                name: "FK_Image_Uploads_Images_Images_Id",
                table: "Image_Uploads",
                column: "Images_Id",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Lines_Orders_Order_Id",
                table: "Order_Lines",
                column: "Order_Id",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_Shipping_Address_Id",
                table: "Orders",
                column: "Shipping_Address_Id",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Order_Status_Order_Status_Id",
                table: "Orders",
                column: "Order_Status_Id",
                principalTable: "Order_Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shipping_Methods_Shipping_Method_Id",
                table: "Orders",
                column: "Shipping_Method_Id",
                principalTable: "Shipping_Methods",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_User_Payment_Methods_Payment_Method_Id",
                table: "Orders",
                column: "Payment_Method_Id",
                principalTable: "User_Payment_Methods",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Uploads_Images_Images_Id",
                table: "Image_Uploads");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Lines_Orders_Order_Id",
                table: "Order_Lines");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_Shipping_Address_Id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Order_Status_Order_Status_Id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shipping_Methods_Shipping_Method_Id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_User_Payment_Methods_Payment_Method_Id",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Order_Lines_Order_Id",
                table: "Order_Lines");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Order_Lines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_Lines_OrderId",
                table: "Order_Lines",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Uploads_Images_Images_Id",
                table: "Image_Uploads",
                column: "Images_Id",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            //
            migrationBuilder.AlterColumn<int>(
               name: "Shipping_Address_Id",
               table: "Orders",
               type: "int",
               nullable: false,
               defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
               name: "Order_Status_Id",
               table: "Orders",
               type: "int",
               nullable: false,
               defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
               name: "Shipping_Method_Id",
               table: "Orders",
               type: "int",
               nullable: false,
               defaultValue: 0);
            migrationBuilder.AlterColumn<int>(
               name: "Payment_Method_Id",
               table: "Orders",
               type: "int",
               nullable: false,
               defaultValue: 0);
            //

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Lines_Orders_OrderId",
                table: "Order_Lines",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_Shipping_Address_Id",
                table: "Orders",
                column: "Shipping_Address_Id",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Order_Status_Order_Status_Id",
                table: "Orders",
                column: "Order_Status_Id",
                principalTable: "Order_Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shipping_Methods_Shipping_Method_Id",
                table: "Orders",
                column: "Shipping_Method_Id",
                principalTable: "Shipping_Methods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_User_Payment_Methods_Payment_Method_Id",
                table: "Orders",
                column: "Payment_Method_Id",
                principalTable: "User_Payment_Methods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

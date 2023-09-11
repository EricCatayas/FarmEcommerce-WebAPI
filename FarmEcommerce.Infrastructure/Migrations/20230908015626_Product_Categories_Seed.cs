using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FarmEcommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Product_Categories_Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product_Categories",
                columns: new[] { "Id", "Category_Name", "Image_Url", "Parent_Category_Id" },
                values: new object[,]
                {
                    { 1, "Fruits", "https://unlimitedworks.blob.core.windows.net/farmecommerce/fruit.png", null },
                    { 2, "Vegetables", "https://unlimitedworks.blob.core.windows.net/farmecommerce/vegetable.png", null },
                    { 3, "Grains", "https://unlimitedworks.blob.core.windows.net/farmecommerce/sack.png", null },
                    { 4, "Livestock", "https://unlimitedworks.blob.core.windows.net/farmecommerce/livestock-icon-128.png", null },
                    { 5, "Herbs", "https://unlimitedworks.blob.core.windows.net/farmecommerce/mortar.png", null },
                    { 6, "Seedlings", "https://unlimitedworks.blob.core.windows.net/farmecommerce/seedlings.png", null },
                    { 7, "Others", "https://unlimitedworks.blob.core.windows.net/farmecommerce/oil.png", null },
                    { 11, "Banana", "https://unlimitedworks.blob.core.windows.net/farmecommerce/banana.png", 1 },
                    { 12, "Mango", "https://unlimitedworks.blob.core.windows.net/farmecommerce/mango.png", 1 },
                    { 14, "Citrus", "https://unlimitedworks.blob.core.windows.net/farmecommerce/citrus-fruits.png", 1 },
                    { 15, "Pineapple", "https://unlimitedworks.blob.core.windows.net/farmecommerce/pineapple.png", 1 },
                    { 17, "Coconut", "https://unlimitedworks.blob.core.windows.net/farmecommerce/coconut.png", 1 },
                    { 18, "Watermelon", "https://unlimitedworks.blob.core.windows.net/farmecommerce/watermelon.png", 1 },
                    { 19, "Dragon Fruit", "https://unlimitedworks.blob.core.windows.net/farmecommerce/dragon-fruit.png", 1 },
                    { 21, "Root Vegetables", "https://unlimitedworks.blob.core.windows.net/farmecommerce/root-vegetable.png", 2 },
                    { 22, "Leafy Greens", "https://unlimitedworks.blob.core.windows.net/farmecommerce/kangkung-leafy-vegetables.png", 2 },
                    { 23, "Cruciferous Vegetables", "https://unlimitedworks.blob.core.windows.net/farmecommerce/cabbage-cruciferous-vegetables.png", 2 },
                    { 24, "Podded Vegetables", "https://unlimitedworks.blob.core.windows.net/farmecommerce/beans.png", 2 },
                    { 25, "Bulb Vegetables", "https://unlimitedworks.blob.core.windows.net/farmecommerce/garlic.png", 2 },
                    { 26, "Fruit Vegetable", "https://unlimitedworks.blob.core.windows.net/farmecommerce/tomato.png", 2 },
                    { 31, "Corn", "https://unlimitedworks.blob.core.windows.net/farmecommerce/corn.png", 3 },
                    { 32, "Rice", "https://unlimitedworks.blob.core.windows.net/farmecommerce/rice-grain.png", 3 },
                    { 41, "Poultry", "https://unlimitedworks.blob.core.windows.net/farmecommerce/chicken.png", 4 },
                    { 42, "Eggs", "https://unlimitedworks.blob.core.windows.net/farmecommerce/eggs.png", 4 },
                    { 43, "Cattle", "https://unlimitedworks.blob.core.windows.net/farmecommerce/cattle.png", 4 },
                    { 44, "Pigs", "https://unlimitedworks.blob.core.windows.net/farmecommerce/pig.png", 4 },
                    { 45, "Goats", "https://unlimitedworks.blob.core.windows.net/farmecommerce/goat.png", 4 },
                    { 71, "Cooking Oil", "https://unlimitedworks.blob.core.windows.net/farmecommerce/cooking-oil.png", 7 },
                    { 72, "Mushrooms", "https://unlimitedworks.blob.core.windows.net/farmecommerce/mushroom.png", 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product_Categories",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}

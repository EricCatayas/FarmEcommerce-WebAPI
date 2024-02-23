using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmEcommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Removed_Image_Uploads_Upload_Date_Default_Value : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Upload_Date",
                table: "Image_Uploads",
                nullable: false,
                defaultValue: null,  // Removing the default value
                oldDefaultValue: new DateTime(2023, 7, 27, 16, 17, 57, 227, DateTimeKind.Local).AddHours(8)); // Old default value
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Upload_Date",
                table: "Image_Uploads",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 27, 16, 17, 57, 227, DateTimeKind.Local).AddHours(8), // Restoring the old default value
                oldDefaultValue: null);
        }
    }
}

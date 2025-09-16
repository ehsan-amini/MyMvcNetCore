using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMvcNetCore.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Date_08_09_2025_Time_21_00_00 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductTags_Title",
                table: "ProductTags");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ProductImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ProductImages");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_Title",
                table: "ProductTags",
                column: "Title",
                unique: true);
        }
    }
}

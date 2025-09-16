using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMvcNetCore.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Date_13_09_2025_Time_12_17_00 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StreetAdress",
                table: "Orders",
                newName: "Adress");

            migrationBuilder.RenameColumn(
                name: "StreetAdress",
                table: "ApplicationUser",
                newName: "Adress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Orders",
                newName: "StreetAdress");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "ApplicationUser",
                newName: "StreetAdress");
        }
    }
}

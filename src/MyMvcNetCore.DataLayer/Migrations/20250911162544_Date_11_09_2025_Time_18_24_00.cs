using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMvcNetCore.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Date_11_09_2025_Time_18_24_00 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_ApplicationUser_UserId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Companies_CompanyId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_UserId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Address",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_CompanyId",
                table: "Address",
                newName: "IX_Address_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_ApplicationUser_ApplicationUserId",
                table: "Address",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_ApplicationUser_ApplicationUserId",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Address",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_ApplicationUserId",
                table: "Address",
                newName: "IX_Address_CompanyId");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                table: "Address",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_ApplicationUser_UserId",
                table: "Address",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Companies_CompanyId",
                table: "Address",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}

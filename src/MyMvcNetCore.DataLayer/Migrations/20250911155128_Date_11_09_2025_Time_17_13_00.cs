using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMvcNetCore.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Date_11_09_2025_Time_17_13_00 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "ApplicationUser",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Address",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_CompanyId",
                table: "ApplicationUser",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CompanyId",
                table: "Address",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Companies_CompanyId",
                table: "Address",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_Companies_CompanyId",
                table: "ApplicationUser",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Companies_CompanyId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_Companies_CompanyId",
                table: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUser_CompanyId",
                table: "ApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_Address_CompanyId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Address");
        }
    }
}

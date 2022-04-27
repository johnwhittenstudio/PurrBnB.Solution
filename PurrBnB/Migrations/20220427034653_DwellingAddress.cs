using Microsoft.EntityFrameworkCore.Migrations;

namespace PurrBnB.Migrations
{
    public partial class DwellingAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DwellingId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DwellingCity",
                table: "Dwellings",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "DwellingState",
                table: "Dwellings",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "DwellingStreetAddress",
                table: "Dwellings",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "DwellingZip",
                table: "Dwellings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DwellingId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "DwellingCity",
                table: "Dwellings");

            migrationBuilder.DropColumn(
                name: "DwellingState",
                table: "Dwellings");

            migrationBuilder.DropColumn(
                name: "DwellingStreetAddress",
                table: "Dwellings");

            migrationBuilder.DropColumn(
                name: "DwellingZip",
                table: "Dwellings");
        }
    }
}

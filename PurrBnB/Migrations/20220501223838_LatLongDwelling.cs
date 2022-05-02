using Microsoft.EntityFrameworkCore.Migrations;

namespace PurrBnB.Migrations
{
    public partial class LatLongDwelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "DwellingLat",
                table: "Dwellings",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "DwellingLong",
                table: "Dwellings",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DwellingLat",
                table: "Dwellings");

            migrationBuilder.DropColumn(
                name: "DwellingLong",
                table: "Dwellings");
        }
    }
}

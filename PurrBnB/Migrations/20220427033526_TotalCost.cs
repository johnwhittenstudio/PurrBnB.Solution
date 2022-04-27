using Microsoft.EntityFrameworkCore.Migrations;

namespace PurrBnB.Migrations
{
    public partial class TotalCost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CostPerNight",
                table: "Dwellings",
                newName: "TotalCost");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalCost",
                table: "Dwellings",
                newName: "CostPerNight");
        }
    }
}

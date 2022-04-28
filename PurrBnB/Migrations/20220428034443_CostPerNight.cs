using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PurrBnB.Migrations
{
    public partial class CostPerNight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Dwellings");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Dwellings");

            migrationBuilder.RenameColumn(
                name: "TotalCost",
                table: "Dwellings",
                newName: "CostPerNight");

            migrationBuilder.RenameColumn(
                name: "TotalCost",
                table: "DwellingReservations",
                newName: "CostPerNight");

            migrationBuilder.AddColumn<int>(
                name: "TotalNights",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalNights",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "CostPerNight",
                table: "Dwellings",
                newName: "TotalCost");

            migrationBuilder.RenameColumn(
                name: "CostPerNight",
                table: "DwellingReservations",
                newName: "TotalCost");

            migrationBuilder.AddColumn<float>(
                name: "TotalCost",
                table: "Reservations",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Dwellings",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Dwellings",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

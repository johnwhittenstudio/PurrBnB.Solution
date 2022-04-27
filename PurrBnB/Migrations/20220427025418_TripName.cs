using Microsoft.EntityFrameworkCore.Migrations;

namespace PurrBnB.Migrations
{
    public partial class TripName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReservationName",
                table: "Reservations",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationName",
                table: "Reservations");
        }
    }
}

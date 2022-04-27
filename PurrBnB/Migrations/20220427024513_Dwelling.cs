using Microsoft.EntityFrameworkCore.Migrations;

namespace PurrBnB.Migrations
{
    public partial class Dwelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Dwellings_DwellingId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_DwellingId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "DwellingId",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Dwellings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dwellings_ReservationId",
                table: "Dwellings",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dwellings_Reservations_ReservationId",
                table: "Dwellings",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dwellings_Reservations_ReservationId",
                table: "Dwellings");

            migrationBuilder.DropIndex(
                name: "IX_Dwellings_ReservationId",
                table: "Dwellings");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Dwellings");

            migrationBuilder.AddColumn<int>(
                name: "DwellingId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_DwellingId",
                table: "Reservations",
                column: "DwellingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Dwellings_DwellingId",
                table: "Reservations",
                column: "DwellingId",
                principalTable: "Dwellings",
                principalColumn: "DwellingId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

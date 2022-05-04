using Microsoft.EntityFrameworkCore.Migrations;

namespace PurrBnB.Migrations
{
    public partial class RemoveImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DwellingPet_Dwellings_DwellingId",
                table: "DwellingPet");

            migrationBuilder.DropForeignKey(
                name: "FK_DwellingReservations_Dwellings_DwellingId",
                table: "DwellingReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Dwellings_AspNetUsers_UserId",
                table: "Dwellings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dwellings",
                table: "Dwellings");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Dwellings");

            migrationBuilder.RenameTable(
                name: "Dwellings",
                newName: "Dwelling");

            migrationBuilder.RenameIndex(
                name: "IX_Dwellings_UserId",
                table: "Dwelling",
                newName: "IX_Dwelling_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dwelling",
                table: "Dwelling",
                column: "DwellingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dwelling_AspNetUsers_UserId",
                table: "Dwelling",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DwellingPet_Dwelling_DwellingId",
                table: "DwellingPet",
                column: "DwellingId",
                principalTable: "Dwelling",
                principalColumn: "DwellingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DwellingReservations_Dwelling_DwellingId",
                table: "DwellingReservations",
                column: "DwellingId",
                principalTable: "Dwelling",
                principalColumn: "DwellingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dwelling_AspNetUsers_UserId",
                table: "Dwelling");

            migrationBuilder.DropForeignKey(
                name: "FK_DwellingPet_Dwelling_DwellingId",
                table: "DwellingPet");

            migrationBuilder.DropForeignKey(
                name: "FK_DwellingReservations_Dwelling_DwellingId",
                table: "DwellingReservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dwelling",
                table: "Dwelling");

            migrationBuilder.RenameTable(
                name: "Dwelling",
                newName: "Dwellings");

            migrationBuilder.RenameIndex(
                name: "IX_Dwelling_UserId",
                table: "Dwellings",
                newName: "IX_Dwellings_UserId");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Dwellings",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dwellings",
                table: "Dwellings",
                column: "DwellingId");

            migrationBuilder.AddForeignKey(
                name: "FK_DwellingPet_Dwellings_DwellingId",
                table: "DwellingPet",
                column: "DwellingId",
                principalTable: "Dwellings",
                principalColumn: "DwellingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DwellingReservations_Dwellings_DwellingId",
                table: "DwellingReservations",
                column: "DwellingId",
                principalTable: "Dwellings",
                principalColumn: "DwellingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dwellings_AspNetUsers_UserId",
                table: "Dwellings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

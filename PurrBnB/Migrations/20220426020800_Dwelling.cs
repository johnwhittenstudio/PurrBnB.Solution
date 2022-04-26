using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PurrBnB.Migrations
{
    public partial class Dwelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DwellingPet",
                columns: table => new
                {
                    DwellingPetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PetId = table.Column<int>(type: "int", nullable: false),
                    DwellingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellingPet", x => x.DwellingPetId);
                    table.ForeignKey(
                        name: "FK_DwellingPet_Dwellings_DwellingId",
                        column: x => x.DwellingId,
                        principalTable: "Dwellings",
                        principalColumn: "DwellingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DwellingPet_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "PetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CostPerNight = table.Column<float>(type: "float", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DwellingReservations",
                columns: table => new
                {
                    DwellingReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DwellingId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DwellingReservations", x => x.DwellingReservationId);
                    table.ForeignKey(
                        name: "FK_DwellingReservations_Dwellings_DwellingId",
                        column: x => x.DwellingId,
                        principalTable: "Dwellings",
                        principalColumn: "DwellingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DwellingReservations_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "ReservationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DwellingPet_DwellingId",
                table: "DwellingPet",
                column: "DwellingId");

            migrationBuilder.CreateIndex(
                name: "IX_DwellingPet_PetId",
                table: "DwellingPet",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_DwellingReservations_DwellingId",
                table: "DwellingReservations",
                column: "DwellingId");

            migrationBuilder.CreateIndex(
                name: "IX_DwellingReservations_ReservationId",
                table: "DwellingReservations",
                column: "ReservationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ApplicationUserId",
                table: "Reservations",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DwellingPet");

            migrationBuilder.DropTable(
                name: "DwellingReservations");

            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}

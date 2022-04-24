using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PurrBnB.Migrations
{
    public partial class UpdateDwellingName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dwellings",
                columns: table => new
                {
                    DwellingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DwellingName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    DwellingOwnerName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    DwellingType = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    DwellingPetId = table.Column<int>(type: "int", nullable: false),
                    GroundLevelAccess = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Kitchen = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NumberOfPeopleAllowed = table.Column<int>(type: "int", nullable: false),
                    Bedrooms = table.Column<int>(type: "int", nullable: false),
                    Bathrooms = table.Column<int>(type: "int", nullable: false),
                    PrivateAccess = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Accomodations = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dwellings", x => x.DwellingId);
                    table.ForeignKey(
                        name: "FK_Dwellings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    PetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Interests = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    FavoriteToys = table.Column<string>(name: "Favorite Toys", type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Schedule = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Personality = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.PetId);
                    table.ForeignKey(
                        name: "FK_Pets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dwellings_UserId",
                table: "Dwellings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_UserId",
                table: "Pets",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dwellings");

            migrationBuilder.DropTable(
                name: "Pets");
        }
    }
}

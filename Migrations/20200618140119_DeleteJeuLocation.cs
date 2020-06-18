using Microsoft.EntityFrameworkCore.Migrations;

namespace PickAndPlay.Migrations
{
    public partial class DeleteJeuLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JeuLocation");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_IdJeu",
                table: "Locations",
                column: "IdJeu");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Jeu",
                table: "Locations",
                column: "IdJeu",
                principalTable: "Jeu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Jeu",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_IdJeu",
                table: "Locations");

            migrationBuilder.CreateTable(
                name: "JeuLocation",
                columns: table => new
                {
                    IdJeu = table.Column<int>(type: "int", nullable: false),
                    IdLocation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JeuLocation", x => new { x.IdJeu, x.IdLocation });
                    table.ForeignKey(
                        name: "Fk_JeuLocation_Jeu",
                        column: x => x.IdJeu,
                        principalTable: "Jeu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_JeuLocation_Location",
                        column: x => x.IdLocation,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JeuLocation_IdLocation",
                table: "JeuLocation",
                column: "IdLocation");
        }
    }
}

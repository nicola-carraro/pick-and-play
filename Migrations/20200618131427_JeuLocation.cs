using Microsoft.EntityFrameworkCore.Migrations;

namespace PickAndPlay.Migrations
{
    public partial class JeuLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Table_2_Jeu",
                table: "Locations");

            migrationBuilder.CreateTable(
                name: "JeuLocation",
                columns: table => new
                {
                    IdJeu = table.Column<int>(nullable: false),
                    IdLocation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JeuLocation", x => x.IdJeu);
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JeuLocation");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_2_Jeu",
                table: "Locations",
                column: "Id",
                principalTable: "Jeu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

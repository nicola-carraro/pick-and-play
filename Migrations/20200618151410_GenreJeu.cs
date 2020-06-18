using Microsoft.EntityFrameworkCore.Migrations;

namespace PickAndPlay.Migrations
{
    public partial class GenreJeu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JeuGenre",
                columns: table => new
                {
                    IdGenre = table.Column<int>(nullable: false),
                    IdJeu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JeuGenre", x => new { x.IdJeu, x.IdGenre });
                    table.ForeignKey(
                        name: "FK_JeuGenre_Genre",
                        column: x => x.IdGenre,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JeuGenre_Jeu",
                        column: x => x.IdJeu,
                        principalTable: "Jeu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JeuGenre_IdGenre",
                table: "JeuGenre",
                column: "IdGenre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JeuGenre");
        }
    }
}

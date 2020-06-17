using Microsoft.EntityFrameworkCore.Migrations;

namespace PickAndPlay.Migrations
{
    public partial class IdJeu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoteJeu_Jeu",
                table: "NotesJeus");

            migrationBuilder.CreateIndex(
                name: "IX_NotesJeus_IdJeu",
                table: "NotesJeus",
                column: "IdJeu",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NoteJeu_Jeu",
                table: "NotesJeus",
                column: "IdJeu",
                principalTable: "Jeu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoteJeu_Jeu",
                table: "NotesJeus");

            migrationBuilder.DropIndex(
                name: "IX_NotesJeus_IdJeu",
                table: "NotesJeus");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteJeu_Jeu",
                table: "NotesJeus",
                column: "Id",
                principalTable: "Jeu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

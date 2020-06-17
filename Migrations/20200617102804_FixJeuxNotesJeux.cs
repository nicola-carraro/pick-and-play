using Microsoft.EntityFrameworkCore.Migrations;

namespace PickAndPlay.Migrations
{
    public partial class FixJeuxNotesJeux : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NotesJeus_IdJeu",
                table: "NotesJeus");

            migrationBuilder.CreateIndex(
                name: "IX_NotesJeus_IdJeu",
                table: "NotesJeus",
                column: "IdJeu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NotesJeus_IdJeu",
                table: "NotesJeus");

            migrationBuilder.CreateIndex(
                name: "IX_NotesJeus_IdJeu",
                table: "NotesJeus",
                column: "IdJeu",
                unique: true);
        }
    }
}

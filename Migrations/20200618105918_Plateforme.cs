using Microsoft.EntityFrameworkCore.Migrations;

namespace PickAndPlay.Migrations
{
    public partial class Plateforme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsolesDeJeu",
                table: "ConsolesDeJeu");

            migrationBuilder.RenameTable(
                name: "ConsolesDeJeu",
                newName: "Platefeforme");

            migrationBuilder.RenameIndex(
                name: "IX_ConsolesDeJeu_IdImage",
                table: "Platefeforme",
                newName: "IX_Platefeforme_IdImage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Platefeforme",
                table: "Platefeforme",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Platefeforme",
                table: "Platefeforme");

            migrationBuilder.RenameTable(
                name: "Platefeforme",
                newName: "ConsolesDeJeu");

            migrationBuilder.RenameIndex(
                name: "IX_Platefeforme_IdImage",
                table: "ConsolesDeJeu",
                newName: "IX_ConsolesDeJeu_IdImage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsolesDeJeu",
                table: "ConsolesDeJeu",
                column: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace PickAndPlay.Migrations
{
    public partial class ForeignKeyEditeur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEditeur",
                table: "Jeu",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jeu_IdEditeur",
                table: "Jeu",
                column: "IdEditeur");

            migrationBuilder.AddForeignKey(
                name: "FK_Jeu_Editeur",
                table: "Jeu",
                column: "IdEditeur",
                principalTable: "Editeur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jeu_Editeur",
                table: "Jeu");

            migrationBuilder.DropIndex(
                name: "IX_Jeu_IdEditeur",
                table: "Jeu");

            migrationBuilder.DropColumn(
                name: "IdEditeur",
                table: "Jeu");
        }
    }
}

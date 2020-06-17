using Microsoft.EntityFrameworkCore.Migrations;

namespace PickAndPlay.Migrations
{
    public partial class FKConsoleImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ConsolesDeJeu_IdImage",
                table: "ConsolesDeJeu",
                column: "IdImage",
                unique: true,
                filter: "[IdImage] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsoleDeJeu_Image",
                table: "ConsolesDeJeu",
                column: "IdImage",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsoleDeJeu_Image",
                table: "ConsolesDeJeu");

            migrationBuilder.DropIndex(
                name: "IX_ConsolesDeJeu_IdImage",
                table: "ConsolesDeJeu");
        }
    }
}

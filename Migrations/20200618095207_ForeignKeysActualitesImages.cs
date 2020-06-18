using Microsoft.EntityFrameworkCore.Migrations;

namespace PickAndPlay.Migrations
{
    public partial class ForeignKeysActualitesImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ActualiteImage_IdImage",
                table: "ActualiteImage",
                column: "IdImage");

            migrationBuilder.AddForeignKey(
                name: "FK_ActualiteImage_Actualite",
                table: "ActualiteImage",
                column: "IdActualite",
                principalTable: "Actualites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActualiteImage_Image",
                table: "ActualiteImage",
                column: "IdImage",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActualiteImage_Actualite",
                table: "ActualiteImage");

            migrationBuilder.DropForeignKey(
                name: "FK_ActualiteImage_Image",
                table: "ActualiteImage");

            migrationBuilder.DropIndex(
                name: "IX_ActualiteImage_IdImage",
                table: "ActualiteImage");
        }
    }
}

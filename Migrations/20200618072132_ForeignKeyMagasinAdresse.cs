using Microsoft.EntityFrameworkCore.Migrations;

namespace PickAndPlay.Migrations
{
    public partial class ForeignKeyMagasinAdresse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Magasins_Adresse",
                table: "Magasins",
                column: "Adresse",
                unique: true,
                filter: "[Adresse] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "Fk_Magasin_Adresse",
                table: "Magasins",
                column: "Adresse",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Fk_Magasin_Adresse",
                table: "Magasins");

            migrationBuilder.DropIndex(
                name: "IX_Magasins_Adresse",
                table: "Magasins");
        }
    }
}

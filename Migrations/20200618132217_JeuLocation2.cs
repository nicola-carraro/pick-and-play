using Microsoft.EntityFrameworkCore.Migrations;

namespace PickAndPlay.Migrations
{
    public partial class JeuLocation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JeuLocation",
                table: "JeuLocation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JeuLocation",
                table: "JeuLocation",
                columns: new[] { "IdJeu", "IdLocation" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JeuLocation",
                table: "JeuLocation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JeuLocation",
                table: "JeuLocation",
                column: "IdJeu");
        }
    }
}

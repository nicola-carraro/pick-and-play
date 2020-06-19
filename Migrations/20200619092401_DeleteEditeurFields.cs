using Microsoft.EntityFrameworkCore.Migrations;

namespace PickAndPlay.Migrations
{
    public partial class DeleteEditeurFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Editeur",
                table: "Jeu");

            migrationBuilder.DropColumn(
                name: "LinkEditeur",
                table: "Jeu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Editeur",
                table: "Jeu",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkEditeur",
                table: "Jeu",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}

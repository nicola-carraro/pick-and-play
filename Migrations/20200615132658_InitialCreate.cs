using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PickAndPlay.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActualiteImage",
                columns: table => new
                {
                    IdActualite = table.Column<int>(nullable: false),
                    IdImage = table.Column<int>(nullable: false)
                },
                constraints: table => table.PrimaryKey("PK_ActualiteImage", x => new { x.IdActualite, x.IdImage }));

            migrationBuilder.CreateTable(
                name: "Actualites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    ResumeCourt = table.Column<string>(nullable: true),
                    ResumeLong = table.Column<string>(nullable: true),
                    Contenu = table.Column<string>(nullable: true)
                },
                constraints: table => table.PrimaryKey("PK_Actualites", x => x.Id));

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rue = table.Column<string>(maxLength: 50, nullable: true),
                    NumeroDeRue = table.Column<string>(fixedLength: true, maxLength: 5, nullable: true),
                    Ville = table.Column<string>(maxLength: 50, nullable: true),
                    CodePostal = table.Column<string>(fixedLength: true, maxLength: 5, nullable: true),
                    Pays = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table => table.PrimaryKey("PK_Adresses", x => x.Id));

            migrationBuilder.CreateTable(
                name: "ConsolesDeJeu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(maxLength: 50, nullable: true),
                    Marque = table.Column<string>(maxLength: 50, nullable: true),
                    IdImage = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table => table.PrimaryKey("PK_ConsolesDeJeu", x => x.Id));

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomFile = table.Column<string>(maxLength: 50, nullable: true),
                    Alt = table.Column<string>(maxLength: 50, nullable: true),
                    Largeur = table.Column<int>(nullable: true),
                    Hauteur = table.Column<int>(nullable: true)
                },
                constraints: table => table.PrimaryKey("PK_Image", x => x.Id));

            migrationBuilder.CreateTable(
                name: "Jeu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateDeSortie = table.Column<DateTime>(type: "date", nullable: true),
                    Editeur = table.Column<string>(maxLength: 50, nullable: true),
                    LinkEditeur = table.Column<string>(maxLength: 50, nullable: true),
                    PEGI = table.Column<byte>(nullable: true),
                    Disponible = table.Column<bool>(nullable: true),
                    PrixLocation = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    PrixAchat = table.Column<decimal>(type: "decimal(18, 0)", nullable: true)
                },
                constraints: table => table.PrimaryKey("PK_Jeu", x => x.Id));

            migrationBuilder.CreateTable(
                name: "Magasins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(maxLength: 50, nullable: true),
                    Gerent = table.Column<int>(nullable: true),
                    Adresse = table.Column<int>(nullable: true)
                },
                constraints: table => table.PrimaryKey("PK_Magasins", x => x.Id));

            migrationBuilder.CreateTable(
                name: "ConsoleJeu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    IdConsole = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsoleJeu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsoleJeu_ConsoleDeJeu",
                        column: x => x.Id,
                        principalTable: "ConsolesDeJeu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JeuConsoleDeJeu",
                columns: table => new
                {
                    IdConsoleDeJeu = table.Column<int>(nullable: false),
                    IdJeu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JeuConsoleDeJeu", x => new { x.IdConsoleDeJeu, x.IdJeu });
                    table.ForeignKey(
                        name: "FK_JeuConsoleDeJeu_ConsoleDeJeu",
                        column: x => x.IdConsoleDeJeu,
                        principalTable: "ConsolesDeJeu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JeuConsoleDeJeu_Jeu",
                        column: x => x.IdJeu,
                        principalTable: "Jeu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JeuImage",
                columns: table => new
                {
                    IdJeu = table.Column<int>(nullable: false),
                    IdImage = table.Column<int>(nullable: false),
                    ImagePrincipale = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JeuImage", x => new { x.IdJeu, x.IdImage });
                    table.ForeignKey(
                        name: "FK_JeuImage_Image",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JeuImage_Jeu",
                        column: x => x.IdJeu,
                        principalTable: "Jeu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUtilisateur = table.Column<string>(maxLength: 450, nullable: true),
                    IdJeu = table.Column<int>(nullable: true),
                    DateHeureLocation = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateRestitutionPrevue = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateRestitutionEffective = table.Column<DateTime>(type: "datetime", nullable: true),
                    Prix = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    Penalite = table.Column<decimal>(type: "decimal(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Table_2_Jeu",
                        column: x => x.Id,
                        principalTable: "Jeu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotesJeus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdJeu = table.Column<int>(nullable: false),
                    Note = table.Column<decimal>(type: "decimal(18, 0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotesJeus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoteJeu_Jeu",
                        column: x => x.Id,
                        principalTable: "Jeu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MagasinImage",
                columns: table => new
                {
                    IdMagasin = table.Column<int>(nullable: false),
                    IdImage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagasinImage", x => new { x.IdMagasin, x.IdImage });
                    table.ForeignKey(
                        name: "FK_MagasinImage_Image",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MagasinImage_Magasin",
                        column: x => x.IdMagasin,
                        principalTable: "Magasins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JeuConsoleDeJeu_IdJeu",
                table: "JeuConsoleDeJeu",
                column: "IdJeu");

            migrationBuilder.CreateIndex(
                name: "IX_JeuImage_IdImage",
                table: "JeuImage",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_MagasinImage_IdImage",
                table: "MagasinImage",
                column: "IdImage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActualiteImage");

            migrationBuilder.DropTable(
                name: "Actualites");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "ConsoleJeu");

            migrationBuilder.DropTable(
                name: "JeuConsoleDeJeu");

            migrationBuilder.DropTable(
                name: "JeuImage");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "MagasinImage");

            migrationBuilder.DropTable(
                name: "NotesJeus");

            migrationBuilder.DropTable(
                name: "ConsolesDeJeu");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Magasins");

            migrationBuilder.DropTable(
                name: "Jeu");
        }
    }
}

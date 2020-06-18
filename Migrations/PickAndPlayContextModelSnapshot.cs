﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PickAndPlay.Models;

namespace PickAndPlay.Migrations
{
    [DbContext(typeof(PickAndPlayContext))]
    partial class PickAndPlayContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PickAndPlay.Models.Actualite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contenu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date");

                    b.Property<string>("ResumeCourt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResumeLong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titre")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Actualites");
                });

            modelBuilder.Entity("PickAndPlay.Models.ActualiteImage", b =>
                {
                    b.Property<int>("IdActualite")
                        .HasColumnType("int");

                    b.Property<int>("IdImage")
                        .HasColumnType("int");

                    b.HasKey("IdActualite", "IdImage");

                    b.HasIndex("IdImage");

                    b.ToTable("ActualiteImage");
                });

            modelBuilder.Entity("PickAndPlay.Models.Adresse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodePostal")
                        .HasColumnType("nchar(5)")
                        .IsFixedLength(true)
                        .HasMaxLength(5);

                    b.Property<string>("NumeroDeRue")
                        .HasColumnType("nchar(5)")
                        .IsFixedLength(true)
                        .HasMaxLength(5);

                    b.Property<string>("Pays")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Rue")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Ville")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("PickAndPlay.Models.ConsoleDeJeu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateDeSortie")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdImage")
                        .HasColumnType("int");

                    b.Property<string>("Marque")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("IdImage")
                        .IsUnique()
                        .HasFilter("[IdImage] IS NOT NULL");

                    b.ToTable("ConsolesDeJeu");
                });

            modelBuilder.Entity("PickAndPlay.Models.ConsoleJeu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdConsole")
                        .HasColumnType("int");

                    b.Property<decimal>("Note")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("Id");

                    b.ToTable("ConsoleJeu");
                });

            modelBuilder.Entity("PickAndPlay.Models.Editeur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Editeur");
                });

            modelBuilder.Entity("PickAndPlay.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alt")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("Hauteur")
                        .HasColumnType("int");

                    b.Property<int?>("Largeur")
                        .HasColumnType("int");

                    b.Property<string>("NomFile")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("PickAndPlay.Models.Jeu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateDeSortie")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Disponible")
                        .HasColumnType("bit");

                    b.Property<string>("Editeur")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LinkEditeur")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte?>("Pegi")
                        .HasColumnName("PEGI")
                        .HasColumnType("tinyint");

                    b.Property<decimal?>("PrixAchat")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal?>("PrixLocation")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.ToTable("Jeu");
                });

            modelBuilder.Entity("PickAndPlay.Models.JeuConsoleDeJeu", b =>
                {
                    b.Property<int>("IdConsoleDeJeu")
                        .HasColumnType("int");

                    b.Property<int>("IdJeu")
                        .HasColumnType("int");

                    b.HasKey("IdConsoleDeJeu", "IdJeu");

                    b.HasIndex("IdJeu");

                    b.ToTable("JeuConsoleDeJeu");
                });

            modelBuilder.Entity("PickAndPlay.Models.JeuImage", b =>
                {
                    b.Property<int>("IdJeu")
                        .HasColumnType("int");

                    b.Property<int>("IdImage")
                        .HasColumnType("int");

                    b.Property<bool>("ImagePrincipale")
                        .HasColumnType("bit");

                    b.HasKey("IdJeu", "IdImage");

                    b.HasIndex("IdImage");

                    b.ToTable("JeuImage");
                });

            modelBuilder.Entity("PickAndPlay.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateHeureLocation")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateRestitutionEffective")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateRestitutionPrevue")
                        .HasColumnType("datetime");

                    b.Property<int?>("IdJeu")
                        .HasColumnType("int");

                    b.Property<string>("IdUtilisateur")
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<decimal?>("Penalite")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal?>("Prix")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("Id");

                    b.HasIndex("IdJeu");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("PickAndPlay.Models.Magasin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Adresse")
                        .HasColumnType("int");

                    b.Property<int?>("Gerent")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Adresse")
                        .IsUnique()
                        .HasFilter("[Adresse] IS NOT NULL");

                    b.ToTable("Magasins");
                });

            modelBuilder.Entity("PickAndPlay.Models.MagasinImage", b =>
                {
                    b.Property<int>("IdMagasin")
                        .HasColumnType("int");

                    b.Property<int>("IdImage")
                        .HasColumnType("int");

                    b.HasKey("IdMagasin", "IdImage");

                    b.HasIndex("IdImage");

                    b.ToTable("MagasinImage");
                });

            modelBuilder.Entity("PickAndPlay.Models.NoteJeu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdJeu")
                        .HasColumnType("int");

                    b.Property<decimal>("Note")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("IdJeu");

                    b.ToTable("NotesJeus");
                });

            modelBuilder.Entity("PickAndPlay.Models.ActualiteImage", b =>
                {
                    b.HasOne("PickAndPlay.Models.Actualite", "ActualiteNavigation")
                        .WithMany("ActualiteImage")
                        .HasForeignKey("IdActualite")
                        .HasConstraintName("FK_ActualiteImage_Actualite")
                        .IsRequired();

                    b.HasOne("PickAndPlay.Models.Image", "ImageNavigation")
                        .WithMany("ActualiteImage")
                        .HasForeignKey("IdImage")
                        .HasConstraintName("FK_ActualiteImage_Image")
                        .IsRequired();
                });

            modelBuilder.Entity("PickAndPlay.Models.ConsoleDeJeu", b =>
                {
                    b.HasOne("PickAndPlay.Models.Image", "ImageNavigation")
                        .WithOne("ConsoleNavigation")
                        .HasForeignKey("PickAndPlay.Models.ConsoleDeJeu", "IdImage")
                        .HasConstraintName("FK_ConsoleDeJeu_Image");
                });

            modelBuilder.Entity("PickAndPlay.Models.ConsoleJeu", b =>
                {
                    b.HasOne("PickAndPlay.Models.ConsoleDeJeu", "ConsoleDeJeuNavigation")
                        .WithOne("ConsoleJeu")
                        .HasForeignKey("PickAndPlay.Models.ConsoleJeu", "Id")
                        .HasConstraintName("FK_ConsoleJeu_ConsoleDeJeu")
                        .IsRequired();
                });

            modelBuilder.Entity("PickAndPlay.Models.JeuConsoleDeJeu", b =>
                {
                    b.HasOne("PickAndPlay.Models.ConsoleDeJeu", "ConsoleDeJeuNavigation")
                        .WithMany("JeuConsoleDeJeu")
                        .HasForeignKey("IdConsoleDeJeu")
                        .HasConstraintName("FK_JeuConsoleDeJeu_ConsoleDeJeu")
                        .IsRequired();

                    b.HasOne("PickAndPlay.Models.Jeu", "IdJeuNavigation")
                        .WithMany("JeuConsoleDeJeu")
                        .HasForeignKey("IdJeu")
                        .HasConstraintName("FK_JeuConsoleDeJeu_Jeu")
                        .IsRequired();
                });

            modelBuilder.Entity("PickAndPlay.Models.JeuImage", b =>
                {
                    b.HasOne("PickAndPlay.Models.Image", "ImageNavigation")
                        .WithMany("JeuImage")
                        .HasForeignKey("IdImage")
                        .HasConstraintName("FK_JeuImage_Image")
                        .IsRequired();

                    b.HasOne("PickAndPlay.Models.Jeu", "IdJeuNavigation")
                        .WithMany("JeuImage")
                        .HasForeignKey("IdJeu")
                        .HasConstraintName("FK_JeuImage_Jeu")
                        .IsRequired();
                });

            modelBuilder.Entity("PickAndPlay.Models.Location", b =>
                {
                    b.HasOne("PickAndPlay.Models.Jeu", "JeuNavigation")
                        .WithMany("Locations")
                        .HasForeignKey("IdJeu")
                        .HasConstraintName("FK_Location_Jeu");
                });

            modelBuilder.Entity("PickAndPlay.Models.Magasin", b =>
                {
                    b.HasOne("PickAndPlay.Models.Adresse", "AdresseNavigation")
                        .WithOne("Magasin")
                        .HasForeignKey("PickAndPlay.Models.Magasin", "Adresse")
                        .HasConstraintName("Fk_Magasin_Adresse");
                });

            modelBuilder.Entity("PickAndPlay.Models.MagasinImage", b =>
                {
                    b.HasOne("PickAndPlay.Models.Image", "ImageNavigation")
                        .WithMany("MagasinImage")
                        .HasForeignKey("IdImage")
                        .HasConstraintName("FK_MagasinImage_Image")
                        .IsRequired();

                    b.HasOne("PickAndPlay.Models.Magasin", "MagasinNavigation")
                        .WithMany("MagasinImage")
                        .HasForeignKey("IdMagasin")
                        .HasConstraintName("FK_MagasinImage_Magasin")
                        .IsRequired();
                });

            modelBuilder.Entity("PickAndPlay.Models.NoteJeu", b =>
                {
                    b.HasOne("PickAndPlay.Models.Jeu", "JeuNavigation")
                        .WithMany("NoteJeu")
                        .HasForeignKey("IdJeu")
                        .HasConstraintName("FK_NoteJeu_Jeu")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

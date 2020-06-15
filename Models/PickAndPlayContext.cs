﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PickAndPlay.Models
{
    public partial class PickAndPlayContext : DbContext
    {
        public PickAndPlayContext()
        {
        }

        public PickAndPlayContext(DbContextOptions<PickAndPlayContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Actualite> Actualite { get; set; }
        public virtual DbSet<ActualiteImage> ActualiteImage { get; set; }
        public virtual DbSet<Adresse> Adresse { get; set; }
        public virtual DbSet<ConsoleDeJeu> ConsoleDeJeu { get; set; }
        public virtual DbSet<ConsoleJeu> ConsoleJeu { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Jeu> Jeu { get; set; }
        public virtual DbSet<JeuConsoleDeJeu> JeuConsoleDeJeu { get; set; }
        public virtual DbSet<JeuImage> JeuImage { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Magasin> Magasin { get; set; }
        public virtual DbSet<MagasinImage> MagasinImage { get; set; }
        public virtual DbSet<NoteJeu> NoteJeu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=PickAndPlay;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActualiteImage>(entity =>
            {
                entity.HasKey(e => new { e.IdActualite, e.IdImage });
            });

            modelBuilder.Entity<Adresse>(entity =>
            {
                entity.Property(e => e.CodePostal).IsFixedLength();

                entity.Property(e => e.NumeroDeRue).IsFixedLength();
            });

            modelBuilder.Entity<ConsoleJeu>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.ConsoleJeu)
                    .HasForeignKey<ConsoleJeu>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConsoleJeu_ConsoleDeJeu");
            });

            modelBuilder.Entity<JeuConsoleDeJeu>(entity =>
            {
                entity.HasKey(e => new { e.IdConsoleDeJeu, e.IdJeu });

                entity.HasOne(d => d.IdConsoleDeJeuNavigation)
                    .WithMany(p => p.JeuConsoleDeJeu)
                    .HasForeignKey(d => d.IdConsoleDeJeu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JeuConsoleDeJeu_ConsoleDeJeu");

                entity.HasOne(d => d.IdJeuNavigation)
                    .WithMany(p => p.JeuConsoleDeJeu)
                    .HasForeignKey(d => d.IdJeu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JeuConsoleDeJeu_Jeu");
            });

            modelBuilder.Entity<JeuImage>(entity =>
            {
                entity.HasKey(e => new { e.IdJeu, e.IdImage });

                entity.HasOne(d => d.IdImageNavigation)
                    .WithMany(p => p.JeuImage)
                    .HasForeignKey(d => d.IdImage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JeuImage_Image");

                entity.HasOne(d => d.IdJeuNavigation)
                    .WithMany(p => p.JeuImage)
                    .HasForeignKey(d => d.IdJeu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JeuImage_Jeu");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Location)
                    .HasForeignKey<Location>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Table_2_Jeu");
            });

            modelBuilder.Entity<MagasinImage>(entity =>
            {
                entity.HasKey(e => new { e.IdMagasin, e.IdImage });

                entity.HasOne(d => d.IdImageNavigation)
                    .WithMany(p => p.MagasinImage)
                    .HasForeignKey(d => d.IdImage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MagasinImage_Image");

                entity.HasOne(d => d.IdMagasinNavigation)
                    .WithMany(p => p.MagasinImage)
                    .HasForeignKey(d => d.IdMagasin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MagasinImage_Magasin");
            });

            modelBuilder.Entity<NoteJeu>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.NoteJeu)
                    .HasForeignKey<NoteJeu>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NoteJeu_Jeu");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

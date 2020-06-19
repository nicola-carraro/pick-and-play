using Microsoft.EntityFrameworkCore;

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
        public virtual DbSet<Actualite> Actualites { get; set; }
        public virtual DbSet<ActualiteImage> ActualiteImage { get; set; }
        public virtual DbSet<Adresse> Adresses { get; set; }
        public virtual DbSet<ConsoleDeJeu> ConsolesDeJeu { get; set; }
        public virtual DbSet<ConsoleJeu> ConsoleJeu { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Jeu> Jeux { get; set; }
        public virtual DbSet<JeuConsoleDeJeu> JeuConsoleDeJeu { get; set; }
        public virtual DbSet<JeuImage> JeuImage { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Magasin> Magasins { get; set; }
        public virtual DbSet<MagasinImage> MagasinImage { get; set; }
        public virtual DbSet<NoteJeu> NotesJeus { get; set; }

        public virtual DbSet<Editeur> Editeur { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DI01; Database=PickAndPlay; User=sa; Password=Anassagora85;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActualiteImage>(entity =>
            {
                entity.HasKey(e => new { e.IdActualite, e.IdImage });

                entity.HasOne(d => d.Actualite)
                      .WithMany(p => p.ActualitesImages)
                      .HasForeignKey(d => d.IdActualite)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_ActualiteImage_Actualite");


                entity.HasOne(d => d.Image)
                      .WithMany(p => p.ActualitesImages)
                      .HasForeignKey(d => d.IdImage)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_ActualiteImage_Image");
            });

            modelBuilder.Entity<Adresse>(entity =>
            {
                entity.Property(e => e.CodePostal).IsFixedLength();

                entity.Property(e => e.NumeroDeRue).IsFixedLength();
            });



            modelBuilder.Entity<ConsoleJeu>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.ConsoleDeJeu)
                    .WithOne(p => p.ConsoleJeu)
                    .HasForeignKey<ConsoleJeu>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConsoleJeu_ConsoleDeJeu");
            });

            modelBuilder.Entity<JeuConsoleDeJeu>(entity =>
            {
                entity.HasKey(e => new { e.IdConsoleDeJeu, e.IdJeu });

                entity.HasOne(d => d.ConsoleDeJeu)
                    .WithMany(p => p.JeuxConsolesDeJeu)
                    .HasForeignKey(d => d.IdConsoleDeJeu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JeuConsoleDeJeu_ConsoleDeJeu");

                entity.HasOne(d => d.Jeu)
                    .WithMany(p => p.JeuxConsolesDeJeu)
                    .HasForeignKey(d => d.IdJeu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JeuConsoleDeJeu_Jeu");
            });

            modelBuilder.Entity<JeuImage>(entity =>
            {
                entity.HasKey(e => new { e.IdJeu, e.IdImage });

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.JeuxImages)
                    .HasForeignKey(d => d.IdImage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JeuImage_Image");

                entity.HasOne(d => d.Jeu)
                    .WithMany(p => p.JeuxImages)
                    .HasForeignKey(d => d.IdJeu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JeuImage_Jeu");
            });

            modelBuilder.Entity<ConsoleDeJeu>(entity =>
            {
                entity.HasOne(d => d.Image)
                      .WithOne(p => p.ConsoleNavigation)
                      .HasForeignKey<ConsoleDeJeu>(d => d.IdImage)
                      .HasConstraintName("FK_ConsoleDeJeu_Image");
            }

            );

            modelBuilder.Entity<Magasin>(entity =>
            entity.HasOne(d => d.AdresseNavigation)
                  .WithOne(p => p.Magasin)
                  .HasForeignKey<Magasin>(d => d.Adresse)
                  .HasConstraintName("Fk_Magasin_Adresse")
            );

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(e => e.Jeu)
                    .WithMany(prop => prop.Locations)
                    .HasForeignKey(e => e.IdJeu)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_Jeu");
            });


            modelBuilder.Entity<Genre>(entity => 
            { 
                entity.Property(entity => entity.Id).ValueGeneratedOnAdd();
            });


            modelBuilder.Entity<JeuGenre>(entity =>
            {
                entity.HasKey(e => new { e.IdJeu, e.IdGenre });

                entity.HasOne(d => d.Jeu)
                    .WithMany(p => p.JeuxGenres)
                    .HasForeignKey(d => d.IdJeu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JeuGenre_Jeu");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.JeuxGenres)
                    .HasForeignKey(d => d.IdGenre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JeuGenre_Genre");
            });

            modelBuilder.Entity<MagasinImage>(entity =>
            {
                entity.HasKey(e => new { e.IdMagasin, e.IdImage });

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.MagasinsImages)
                    .HasForeignKey(d => d.IdImage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MagasinImage_Image");

                entity.HasOne(d => d.Magasin)
                    .WithMany(p => p.MagasinsImages)
                    .HasForeignKey(d => d.IdMagasin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MagasinImage_Magasin");
            });

            modelBuilder.Entity<NoteJeu>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Jeu)
                    .WithMany(p => p.NotesJeux)
                    .HasForeignKey(d => d.IdJeu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NoteJeu_Jeu");
            });

            modelBuilder.Entity<Jeu>(entity =>
            {
                entity.HasOne(d => d.Editeur)
                      .WithMany(d => d.Jeux)
                      .HasForeignKey(d => d.IdEditeur)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_Jeu_Editeur");
                
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

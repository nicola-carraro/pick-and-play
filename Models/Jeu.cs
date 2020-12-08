using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PickAndPlay.Models
{
    [Table("Jeu")]
    public partial class Jeu
    {
        public Jeu()
        {
            JeuxConsolesDeJeu = new HashSet<JeuConsoleDeJeu>();
            JeuxImages = new HashSet<JeuImage>();
        }

        [Key]
        public int Id { get; set; }

        public int? IdEditeur { get; set; }

        [ForeignKey(nameof(IdEditeur))]
        [InverseProperty(nameof(Models.Editeur.Jeux))]
        public Editeur Editeur { get; set; }

        [StringLength(50)]
        public string Nom { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateDeSortie { get; set; }

        [Column("PEGI")]
        public byte? Pegi { get; set; }

        public bool? Disponible { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PrixLocation { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PrixAchat { get; set; }

        [InverseProperty(nameof(NoteJeu.Jeu))]
        public virtual ICollection<NoteJeu> NotesJeux { get; set; }

        [InverseProperty(nameof(Location.Jeu))]
        public virtual ICollection<Location> Locations { get; set; }

        [InverseProperty(nameof(JeuConsoleDeJeu.Jeu))]
        public virtual ICollection<JeuConsoleDeJeu> JeuxConsolesDeJeu { get; set; }

        [InverseProperty(nameof(JeuImage.Jeu))]
        public virtual ICollection<JeuImage> JeuxImages { get; set; }

        [InverseProperty(nameof(JeuGenre.Jeu))]
        public virtual ICollection<JeuGenre> JeuxGenres { get; set; }

        [NotMapped()]
        public virtual Image ImagePrincipale
        {
            get
            {
                Image resultat = null;

                if (JeuxImages != null)
                {
                    JeuImage jeuImage = JeuxImages.FirstOrDefault(ji => ji.ImagePrincipale);
                    if (jeuImage != null)
                    {
                        resultat = jeuImage.Image;
                    }
                }

                return resultat;
            }
        }

        [NotMapped()]
        public virtual Image ImageGrande
        {
            get
            {
                if (JeuxImages == null)

                {
                    return null;
                }
                else
                {
                    var jeuImage = JeuxImages.FirstOrDefault(ji => ji.Image.Largeur >= 1000);

                    return jeuImage?.Image;
                }
            }
        }

        [NotMapped()]
        public virtual List<Image> Images
        {
            get
            {
                List<Image> images = new List<Image>();

                if (JeuxImages != null)
                {
                    JeuxImages.ToList().ForEach(ji => images.Add(ji.Image));
                }

                return images;
            }
        }

        [NotMapped()]
        public List<ConsoleDeJeu> Consoles
        {
            get
            {
                List<ConsoleDeJeu> consoles = new List<ConsoleDeJeu>();

                if (JeuxImages != null)
                {
                    JeuxConsolesDeJeu.ToList().ForEach(jc => consoles.Add(jc.ConsoleDeJeu));
                }

                return consoles;
            }
        }

        public decimal? NoteMoyenne()
        {
            if (NotesJeux == null || NotesJeux.Count == 0)
            {
                return null;
            }

            decimal resultat = 0;

            foreach (var note in NotesJeux)
            {
                resultat += note.Note;
            }

            return resultat / NotesJeux.Count;
        }
    }
}

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
            JeuConsoleDeJeu = new HashSet<JeuConsoleDeJeu>();
            JeuImage = new HashSet<JeuImage>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Nom { get; set; }

        public string Description { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateDeSortie { get; set; }

        [StringLength(50)]
        public string Editeur { get; set; }


        [StringLength(50)]
        public string LinkEditeur { get; set; }
        [Column("PEGI")]
        public byte? Pegi { get; set; }
        public bool? Disponible { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PrixLocation { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PrixAchat { get; set; }

        [InverseProperty("IdNavigation")]
        public virtual Location Location { get; set; }
        [InverseProperty("JeuNavigation")]
        public virtual ICollection<NoteJeu> NoteJeu { get; set; }


        [InverseProperty("IdJeuNavigation")]

        
        public virtual ICollection<JeuConsoleDeJeu> JeuConsoleDeJeu { get; set; }
        [InverseProperty("IdJeuNavigation")]
        public virtual ICollection<JeuImage> JeuImage { get; set; }

        [NotMapped()]
        public virtual Image ImagePrincipale { get; set; }


        [NotMapped()]
        public virtual ICollection<Image> Images { get; set; }

        public decimal? NoteMoyenne()
        {

            if(NoteJeu == null || NoteJeu.Count == 0)

            {
                return null;
            }


            decimal resultat = 0;

            foreach (var note in NoteJeu)
            {
                resultat += note.Note;
            };

            return resultat / NoteJeu.Count;
        }

    }
}

﻿using System;
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
        public virtual Image ImagePrincipale
        {
            get
            {
                if (JeuImage == null)

                {
                    return null;
                }

                else
                {
                    return JeuImage.Where(ji => ji.ImagePrincipale)
                                   .FirstOrDefault()
                                   .ImageNavigation;
                }


            }
            set { }
       
        }

        [NotMapped()]
        public virtual Image ImageGrande
        {
            get
            {
                if (JeuImage == null)

                {
                    return null;
                }

                else
                {
                    var jeuImage = JeuImage.Where(ji => ji.ImageNavigation.Largeur >= 1000)
                                    .FirstOrDefault();

                    return jeuImage == null ? 
                            null : 
                            jeuImage.ImageNavigation;
                }

            }

        }


        [NotMapped()]
        public virtual List<Image> Images
        {
            get
            {

                List<Image> images = new List<Image>();

                if (JeuImage != null)
                {
                    JeuImage.ToList().ForEach(ji => images.Add(ji.ImageNavigation));
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

                if (JeuImage != null)
                {
                    JeuConsoleDeJeu.ToList().ForEach(jc => consoles.Add(jc.ConsoleDeJeuNavigation));
                }

                return consoles;
            }

        }



 
        public decimal? NoteMoyenne()
        {

            if (NoteJeu == null || NoteJeu.Count == 0)

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

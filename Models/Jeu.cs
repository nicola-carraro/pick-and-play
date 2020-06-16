﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAndPlay.Models
{
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
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? PrixLocation { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? PrixAchat { get; set; }

        [InverseProperty("IdNavigation")]
        public virtual Location Location { get; set; }
        [InverseProperty("IdNavigation")]
        public virtual NoteJeu NoteJeu { get; set; }
        [InverseProperty("IdJeuNavigation")]
        public virtual ICollection<JeuConsoleDeJeu> JeuConsoleDeJeu { get; set; }
        [InverseProperty("IdJeuNavigation")]
        public virtual ICollection<JeuImage> JeuImage { get; set; }

        [NotMapped()]
        public virtual Image ImagePrincipale { get; set; }


        [NotMapped()]
        public virtual ICollection<Image> Images{ get; set; }
    }
}
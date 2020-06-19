using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAndPlay.Models
{
    public partial class JeuImage
    {
        [Key]
        public int IdJeu { get; set; }
        [Key]
        public int IdImage { get; set; }
        public bool ImagePrincipale { get; set; }

        [ForeignKey(nameof(IdImage))]
        [InverseProperty(nameof(Models.Image.JeuxImages))]
        public virtual Image Image { get; set; }
        [ForeignKey(nameof(IdJeu))]
        [InverseProperty(nameof(Models.Jeu.JeuxImages))]
        public virtual Jeu Jeu { get; set; }
    }
}

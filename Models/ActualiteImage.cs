using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAndPlay.Models
{
    public partial class ActualiteImage
    {
        [Key]
        public int IdActualite { get; set; }
        [Key]
        public int IdImage { get; set; }

        [ForeignKey(nameof(IdActualite))]
        [InverseProperty(nameof(Models.Actualite.ActualitesImages))]
        public Actualite Actualite { get; set; }


        [ForeignKey(nameof(IdImage))]
        [InverseProperty(nameof(Models.Image.ActualitesImages))]
        public Image Image { get; set; }
    }
}

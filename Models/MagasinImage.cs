using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAndPlay.Models
{
    public partial class MagasinImage
    {
        [Key]
        public int IdMagasin { get; set; }
        [Key]
        public int IdImage { get; set; }

        [ForeignKey(nameof(IdImage))]
        [InverseProperty(nameof(Image.MagasinImage))]
        public virtual Image IdImageNavigation { get; set; }
        [ForeignKey(nameof(IdMagasin))]
        [InverseProperty(nameof(Magasin.MagasinImage))]
        public virtual Magasin IdMagasinNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAndPlay.Models
{
    public partial class Magasin
    {
        public Magasin()
        {
            MagasinImage = new HashSet<MagasinImage>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Nom { get; set; }
        public int? Gerent { get; set; }
        public int? Adresse { get; set; }

        [InverseProperty("IdMagasinNavigation")]
        public virtual ICollection<MagasinImage> MagasinImage { get; set; }
    }
}

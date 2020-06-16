using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAndPlay.Models
{
    public partial class Image
    {
        public Image()
        {
            JeuImage = new HashSet<JeuImage>();
            MagasinImage = new HashSet<MagasinImage>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string NomFile { get; set; }


        [StringLength(50)]
        public string Alt { get; set; }

        public int? Largeur { get; set; }
        public int? Hauteur { get; set; }

        [InverseProperty("IdImageNavigation")]
        public virtual ICollection<JeuImage> JeuImage { get; set; }
        [InverseProperty("IdImageNavigation")]
        public virtual ICollection<MagasinImage> MagasinImage { get; set; }
    }
}

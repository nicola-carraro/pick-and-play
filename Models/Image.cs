using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAndPlay.Models
{
    [Table("Image")]
    public partial class Image
    {
        public Image()
        {
            JeuxImages = new HashSet<JeuImage>();
            MagasinsImages = new HashSet<MagasinImage>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string NomFile { get; set; }

        [StringLength(50)]
        public string Alt { get; set; }

        public int? Largeur { get; set; }

        public int? Hauteur { get; set; }

        [InverseProperty(nameof(JeuImage.Image))]
        public virtual ICollection<JeuImage> JeuxImages { get; set; }

        [InverseProperty(nameof(MagasinImage.Image))]
        public virtual ICollection<MagasinImage> MagasinsImages { get; set; }

        [InverseProperty(nameof(ConsoleDeJeu.Image))]
        public virtual ConsoleDeJeu ConsoleNavigation { get; set; }

        [InverseProperty(nameof(ActualiteImage.Image))]
        public virtual ICollection<ActualiteImage> ActualitesImages { get; set; }
    }
}

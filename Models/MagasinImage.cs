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
        [InverseProperty(nameof(Models.Image.MagasinsImages))]
        public virtual Image Image { get; set; }

        [ForeignKey(nameof(IdMagasin))]
        [InverseProperty(nameof(Models.Magasin.MagasinsImages))]
        public virtual Magasin Magasin { get; set; }
    }
}

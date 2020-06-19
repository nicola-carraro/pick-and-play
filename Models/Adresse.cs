using System.ComponentModel.DataAnnotations;

namespace PickAndPlay.Models
{
    public partial class Adresse
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Rue { get; set; }
        [StringLength(5)]
        public string NumeroDeRue { get; set; }
        [StringLength(50)]
        public string Ville { get; set; }
        [StringLength(5)]
        public string CodePostal { get; set; }
        [StringLength(50)]
        public string Pays { get; set; }

        public virtual Magasin Magasin { get; set; }
    }
}

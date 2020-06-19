using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAndPlay.Models
{
    public class Editeur
    {
        [Key]
        public int Id { get; set; }


        [StringLength(50)]
        public string Link { get; set; }

        [StringLength(50)]
        public string Nom { get; set; }

        [InverseProperty(nameof(Jeu.Editeur))]
        public ICollection<Jeu> Jeux { get; set; }

    }
}

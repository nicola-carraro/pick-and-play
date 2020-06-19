using System.ComponentModel.DataAnnotations;

namespace PickAndPlay.Models
{
    public class Editeur
    {
        [Key]
        public int Id { get; set;  }


        [StringLength(50)]
        public string Link { get; set; }

        [StringLength(50)]
        public string Nom { get; set; }
    }
}

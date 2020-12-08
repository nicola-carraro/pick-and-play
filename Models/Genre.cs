using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAndPlay.Models
{
    [Table("Genre")]
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        public string Libelle { get; set; }

        [InverseProperty(nameof(JeuGenre.Genre))]
        public virtual ICollection<JeuGenre> JeuxGenres { get; set; }
    }
}

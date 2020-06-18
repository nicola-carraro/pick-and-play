using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndPlay.Models
{
    [Table("Genre")]
    public class Genre
    {
        [Key]
        public int Id { get; set; }
    
    
        public string Libelle { get; set; }


        [InverseProperty("GenreNavigation")]
        public virtual ICollection<JeuGenre> JeuGenre { get; set; }

    }
}

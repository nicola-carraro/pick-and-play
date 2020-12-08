using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAndPlay.Models
{
    public class JeuGenre
    {
        [Key]
        public int IdGenre { get; set; }

        [Key]
        public int IdJeu { get; set; }

        [ForeignKey(nameof(IdGenre))]
        [InverseProperty(nameof(Models.Genre.JeuxGenres))]
        public Genre Genre { get; set; }

        [ForeignKey(nameof(IdJeu))]
        [InverseProperty(nameof(Models.Jeu.JeuxGenres))]
        public Jeu Jeu { get; set; }
    }
}

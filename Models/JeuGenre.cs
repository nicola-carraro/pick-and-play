using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndPlay.Models
{
    public class JeuGenre
    {

        [Key]
        public int IdGenre { get; set; }


        [Key]
        public int IdJeu { get; set; }


        [ForeignKey(nameof(IdGenre))]
        [InverseProperty(nameof(Genre.JeuGenre))]
        public Genre GenreNavigation { get; set; }


        [ForeignKey(nameof(IdJeu))]
        [InverseProperty(nameof(Jeu.JeuGenre))]
        public Jeu JeuNavigation { get; set; }
    }
}

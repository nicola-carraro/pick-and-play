using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAndPlay.Models
{
    public partial class JeuConsoleDeJeu
    {
        [Key]
        public int IdConsoleDeJeu { get; set; }
        [Key]
        public int IdJeu { get; set; }

        [ForeignKey(nameof(IdConsoleDeJeu))]
        [InverseProperty(nameof(Models.ConsoleDeJeu.JeuxConsolesDeJeu))]
        public virtual ConsoleDeJeu ConsoleDeJeu { get; set; }
        [ForeignKey(nameof(IdJeu))]
        [InverseProperty(nameof(Models.Jeu.JeuxConsolesDeJeu))]
        public virtual Jeu? Jeu { get; set; }
    }
}

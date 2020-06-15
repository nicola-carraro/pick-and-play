using System;
using System.Collections.Generic;
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
        [InverseProperty(nameof(ConsoleDeJeu.JeuConsoleDeJeu))]
        public virtual ConsoleDeJeu IdConsoleDeJeuNavigation { get; set; }
        [ForeignKey(nameof(IdJeu))]
        [InverseProperty(nameof(Jeu.JeuConsoleDeJeu))]
        public virtual Jeu IdJeuNavigation { get; set; }
    }
}

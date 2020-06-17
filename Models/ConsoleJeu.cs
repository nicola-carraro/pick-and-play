using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAndPlay.Models
{
    public partial class ConsoleJeu
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Note { get; set; }
        public int IdConsole { get; set; }

        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(ConsoleDeJeu.ConsoleJeu))]
        public virtual ConsoleDeJeu ConsoleDeJeuNavigation { get; set; }


      
    }
}

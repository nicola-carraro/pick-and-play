using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAndPlay.Models
{
    public partial class NoteJeu
    {
        [Key]
        public int Id { get; set; }
        public int IdJeu { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Note { get; set; }

        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(Jeu.NoteJeu))]
        public virtual Jeu IdNavigation { get; set; }
    }
}

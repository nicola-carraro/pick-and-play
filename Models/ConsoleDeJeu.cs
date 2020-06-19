using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAndPlay.Models
{

    public partial class ConsoleDeJeu
    {
        public ConsoleDeJeu()
        {
            JeuxConsolesDeJeu = new HashSet<JeuConsoleDeJeu>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        [StringLength(50)]
        public string Marque { get; set; }

        public int? IdImage { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateDeSortie { get; set; }


        [InverseProperty(nameof(Models.ConsoleJeu.ConsoleDeJeu))]
        public virtual ConsoleJeu ConsoleJeu { get; set; }

        [InverseProperty(nameof(JeuConsoleDeJeu.ConsoleDeJeu))]
        public virtual ICollection<JeuConsoleDeJeu> JeuxConsolesDeJeu { get; set; }

        [ForeignKey(nameof(IdImage))]
        public virtual Image Image { get; set; }
    }
}

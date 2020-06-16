﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAndPlay.Models
{
    public partial class ConsoleDeJeu
    {
        public ConsoleDeJeu()
        {
            JeuConsoleDeJeu = new HashSet<JeuConsoleDeJeu>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Model { get; set; }
        [StringLength(50)]
        public string Marque { get; set; }
        public int? IdImage { get; set; }
        public string Description { get; set; }

        [InverseProperty("IdNavigation")]
        public virtual ConsoleJeu ConsoleJeu { get; set; }
        [InverseProperty("IdConsoleDeJeuNavigation")]
        public virtual ICollection<JeuConsoleDeJeu> JeuConsoleDeJeu { get; set; }
    }
}
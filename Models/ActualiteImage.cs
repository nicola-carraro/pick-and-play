using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAndPlay.Models
{
    public partial class ActualiteImage
    {
        [Key]
        public int IdActualite { get; set; }
        [Key]
        public int IdImage { get; set; }
    }
}

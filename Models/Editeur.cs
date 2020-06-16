using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndPlay.Models
{
    public class Editeur
    {

        [Key]
        public int Id { get; set;  }


        [StringLength(50)]
        public string Link { get; set; }

        [StringLength(50)]
        public string Nom { get; set; }
    }
}

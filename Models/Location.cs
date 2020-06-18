using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAndPlay.Models
{
    public partial class Location
    {
        [StringLength(450)]
        public string IdUtilisateur { get; set; }
        
        public int? IdJeu { get; set; }
        
        [Key]
        public int Id { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? DateHeureLocation { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? DateRestitutionPrevue { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? DateRestitutionEffective { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Prix { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Penalite { get; set; }

        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(Jeu.Location))]
        public virtual Jeu IdNavigation { get; set; }
    }
}

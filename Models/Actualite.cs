using PickAndPlay.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAndPlay.Models
{
    public partial class Actualite
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Titre { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }
        public string ResumeCourt { get; set; }
        public string ResumeLong { get; set; }
        public string Contenu { get; set; }

        [InverseProperty("ActualiteNavigation")]
        public virtual ICollection<ActualiteImage> ActualiteImage { get; set; }

        [NotMapped]
        public List<Image> Images
        {
            get
            {
                List<Image> images = new List<Image>();

                if (ActualiteImage != null)
                {
                    foreach (var ai in ActualiteImage)
                    {
                        if (ai != null && ai.Image != null)
                        {
                            images.Add(ai.Image);
                        }
                    }
                }

                return images;
            }
        }
    }
}

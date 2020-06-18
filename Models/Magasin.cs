using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAndPlay.Models
{
    public partial class Magasin
    {
        public Magasin()
        {
            MagasinImage = new HashSet<MagasinImage>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Nom { get; set; }
        public int? Gerent { get; set; }
        public int? Adresse { get; set; }

        [ForeignKey(nameof(Adresse))]
        public Adresse AdresseNavigation { get; set; }


        [InverseProperty("MagasinNavigation")]
        public virtual ICollection<MagasinImage> MagasinImage { get; set; }

        [NotMapped]
        public List<Image> Images 
        { 
            get
            {
                List<Image> images = new List<Image>();

                if (MagasinImage != null)
                {
                    foreach (var mi in MagasinImage)
                    {
                        if (mi.ImageNavigation != null)
                        {
                            images.Add(mi.ImageNavigation); 
                        }
                    }
                }

                return images;
            }
        }
    }
}

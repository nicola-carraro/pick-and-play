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
            MagasinsImages = new HashSet<MagasinImage>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Nom { get; set; }
        public int? Gerent { get; set; }
        public int? Adresse { get; set; }

        [ForeignKey(nameof(Adresse))]
        public Adresse AdresseNavigation { get; set; }


        [InverseProperty(nameof(MagasinImage.Magasin))]
        public virtual ICollection<MagasinImage> MagasinsImages { get; set; }

        [NotMapped]
        public List<Image> Images 
        { 
            get
            {
                List<Image> images = new List<Image>();

                if (MagasinsImages != null)
                {
                    foreach (var mi in MagasinsImages)
                    {
                        if (mi.Image != null)
                        {
                            images.Add(mi.Image); 
                        }
                    }
                }

                return images;
            }
        }
    }
}

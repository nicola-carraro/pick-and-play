using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAndPlay.Models
{
    public partial class NoteJeu
    {
        [Key]
        public int Id { get; set; }
        public int IdJeu { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Note { get; set; }

        [ForeignKey(nameof(IdJeu))]
        [InverseProperty(nameof(Models.Jeu.NotesJeux))]
        public virtual Jeu Jeu { get; set; }
    }
}

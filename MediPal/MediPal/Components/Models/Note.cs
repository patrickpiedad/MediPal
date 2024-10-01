using MediPal.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediPal.Models
{
    public class Note
    {
        [Key]
        public int NoteID { get; set; }

        [Required]
        public string? NoteTitle { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "Symptom description cannot exceed 1000 characters.")]
        public string? NoteDescription { get; set; }

        [Required]
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}

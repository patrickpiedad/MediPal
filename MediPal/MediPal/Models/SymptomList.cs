using System.ComponentModel.DataAnnotations;

namespace MediPal.Models
{
    public class SymptomList
    {
        [Key]
        public int SymptomID { get; set; }
        public string? Symptom { get; set; }
        public DateOnly Date { get; set; }
        public int PainLevel { get; set; }
        public string? Activity { get; set; }
    }
}

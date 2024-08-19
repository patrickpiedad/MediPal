using System.ComponentModel.DataAnnotations;

namespace MediPal.Models
{
    public class SymptomList
    {

        private int? _symptomID;
        private string? _symptom;
        private DateOnly? _date;
        private int? _painLevel;
        private string? _activity;

        [Key]
        public int? SymptomID { get => _symptomID; set => _symptomID=value; }
        public string? Symptom { get => _symptom; set => _symptom=value; }
        public DateOnly? Date { get => _date; set => _date=value; }
        public int? PainLevel { get => _painLevel; set => _painLevel=value; }
        public string? Activity { get => _activity; set => _activity=value; }
    }
}

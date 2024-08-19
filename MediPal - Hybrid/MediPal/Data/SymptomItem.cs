using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediPal.Data
{
    internal class SymptomItem
    {
        private string? _symptom;
        private DateOnly? _date;
        private int? _painLevel;
        private string? _activity;

        public string? Symptom { get => _symptom; set => _symptom=value; }
        public DateOnly? Date { get => _date; set => _date=value; }
        public int? PainLevel { get => _painLevel; set => _painLevel=value; }
        public string? Activity { get => _activity; set => _activity=value; }

        public SymptomItem()
        {
            this.Symptom = "";
            this.Date = null;
            this.PainLevel = 0;
            this.Activity = "";
        }

        public SymptomItem(string Symptom, DateOnly Date, int PainLevel, string Activity)
        {
            this.Symptom = Symptom;
            this.Date = Date;
            this.PainLevel = PainLevel;
            this.Activity = Activity;
        }
    }
}

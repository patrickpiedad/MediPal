using MediPal.Data;
using MediPal.Models;
using Microsoft.EntityFrameworkCore;

namespace MediPal.Services
{
    public class SymptomService : ISymptomService // SymptomService inherits from ISymptomService
    {
        private readonly MediPalContext _context;

        public SymptomService(MediPalContext context)
        {
            _context=context;
        }
        public async Task<List<Symptom>> GetAllSymptomsAsync()
        {
            await Task.Delay(1000);
            var symptoms = await _context.Symptoms.ToListAsync();
            return symptoms;
        }
        public async Task<Symptom> GetSymptomByIdAsync(int id)
        {
            var symptom = await _context.Symptoms.FindAsync(id);
            return symptom;
        }

        public async Task AddSymptomAsync(Symptom symptom)
        {
            _context.Symptoms.Add(symptom);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSymptomAsync(int id)
        {
            var symptom = await _context.Symptoms.FindAsync(id);
            if (symptom != null)
            {
                _context.Symptoms.Remove(symptom);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateSymptomAsync(Symptom symptom, int id)
        {
            var dbSymptom = await _context.Symptoms.FindAsync(id);
            if (dbSymptom != null)
            {
                dbSymptom.SymptomName = symptom.SymptomName;
                dbSymptom.Date = symptom.Date;
                dbSymptom.PainLevel = symptom.PainLevel;
                dbSymptom.Activity = symptom.Activity;
                await _context.SaveChangesAsync();
            }
        }
    }
}

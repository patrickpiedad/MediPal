using MediPal.Data;
using MediPal.Models;
using Microsoft.EntityFrameworkCore;

namespace MediPal.Components.Services
{
    public class SymptomService : ISymptomService // SymptomService inherits from ISymptomService
    {
        private readonly ApplicationDbContext _context;

        public SymptomService(ApplicationDbContext context)
        {
            _context=context;
        }
        public async Task<List<Symptom>> GetAllSymptomsAsync()
        {
            //await Task.Delay(500);
            var symptoms = await _context.Symptoms.ToListAsync();
            return symptoms;
        }

        // This is the method that gets all symptoms belonging to the specific userId
        public async Task<List<Symptom>> GetSymptomsByUserIdAsync(string userId)
        {
            //await Task.Delay(500);
            return await _context.Symptoms
                .Where(s => s.User.Id == userId)
                .ToListAsync();
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

        public async Task DeleteSymptomAsync(int id, string userId)
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
                dbSymptom.DoctorsNote = symptom.DoctorsNote;
                await _context.SaveChangesAsync();
            }
        }
    }
}

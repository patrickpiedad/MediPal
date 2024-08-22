using MediPal.Shared.Data;
using MediPal.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace MediPal.Shared.Services
{
    public class SymptomService : ISymptomService
    {
        private readonly MediPalContext _context;

        public SymptomService(MediPalContext context)
        {
            _context=context;
        }

        public async Task<List<Symptom>> GetAllSymptoms()
        {
            await Task.Delay(1000);
            var symptoms = await _context.Symptoms.ToListAsync();
            return symptoms;
        }

        async Task<Symptom> ISymptomService.AddSymptom(Symptom symptom)
        {
            _context.Symptoms.Add(symptom);
            await _context.SaveChangesAsync();
            return symptom; // SQLite returns symptom with ID automatically assigned
        }
    }
}

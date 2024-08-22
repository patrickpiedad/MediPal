using MediPal.Models;

namespace MediPal.Services
{
    public interface ISymptomService
    {
        Task<List<Symptom>> GetAllSymptoms();
        Task<Symptom>AddSymptom(Symptom symptom);
    }
}

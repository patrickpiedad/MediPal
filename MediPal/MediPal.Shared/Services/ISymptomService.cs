using MediPal.Shared.Models;

namespace MediPal.Shared.Services
{
    public interface ISymptomService
    {
        Task<List<Symptom>> GetAllSymptoms();
        Task<Symptom>AddSymptom(Symptom symptom);
    }
}

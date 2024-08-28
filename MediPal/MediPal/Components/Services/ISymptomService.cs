using MediPal.Models;

namespace MediPal.Components.Services
{
    public interface ISymptomService
    {
        Task<List<Symptom>> GetAllSymptomsAsync();
        Task<Symptom>GetSymptomByIdAsync(int id);
        Task AddSymptomAsync(Symptom symptom);
        Task UpdateSymptomAsync(Symptom symptom, int id);
        Task DeleteSymptomAsync(int id);
    }
}

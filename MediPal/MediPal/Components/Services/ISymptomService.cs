using MediPal.Models;

namespace MediPal.Components.Services
{
    public interface ISymptomService
    {
        Task<List<Symptom>> GetAllSymptomsAsync();
        Task<List<Symptom>> GetSymptomsByUserIdAsync(string userId); // This method gets all symptoms by ASPNETUserId, instead of just all symptoms
        Task<List<Symptom>> GetSymptomsByPatientIdAsync(string patientId); // This method gets all symptoms based on patientId
        Task<Symptom> GetSymptomByIdAsync(int id);

        Task AddSymptomAsync(Symptom symptom);
        Task UpdateSymptomAsync(Symptom symptom, int id);
        Task DeleteSymptomAsync(int id, string userId);
    }
}

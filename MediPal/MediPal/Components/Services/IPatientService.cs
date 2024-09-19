using MediPal.Components.Models;

namespace MediPal.Components.Services
{
    public interface IPatientService
    {
        Task<List<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientByIdAsync(int id);
        Task AddPatientAsync(Patient symptom);
        Task UpdatePatientAsync(Patient symptom, int id);
        Task DeletePatientAsync(int id);
    }
}

using MediPal.Components.Models;
using MediPal.Data;

namespace MediPal.Components.Services
{
    public interface IPatientService
    {
        Task<ApplicationUser> GetPatientByUserIdAsync(string userId);
        Task<List<ApplicationUser>> GetAllPatientsAsync();
    }
}
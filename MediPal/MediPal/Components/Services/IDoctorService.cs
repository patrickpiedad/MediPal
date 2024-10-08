using MediPal.Components.Models;
using MediPal.Data;

namespace MediPal.Components.Services
{        
    public interface IDoctorService
    {
        Task<List<ApplicationUser>> GetAllDoctorsAsync();
    }
}
using MediPal.Models;
using System.Collections.ObjectModel;

namespace MediPal.Components.Services
{
    public interface IAppointmentService
    {
        Task<List<Appointment>> GetAllAppointmentsAsync();
        Task<List<Appointment>> GetAppointmentsByUserIdAsync(string userId); // This method gets all appointments by ASPNETUserId, instead of just all appointments
        Task<Appointment> GetAppointmentByIdAsync(int id);
        Task AddAppointmentAsync(Appointment appointment);
        Task UpdateAppointmentAsync(Appointment appointment, int id);
        Task DeleteAppointmentAsync(int id, string userId);
    }
}

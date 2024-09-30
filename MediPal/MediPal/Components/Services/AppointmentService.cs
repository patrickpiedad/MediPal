using MediPal.Data;
using MediPal.Models;
using Microsoft.EntityFrameworkCore;

namespace MediPal.Components.Services
{
    public class AppointmentService : IAppointmentService // AppointmentService inherits from IAppointmentService
    {
        private readonly ApplicationDbContext _context;

        public AppointmentService(ApplicationDbContext context)
        {
            _context=context;
        }
        public async Task<List<Appointment>> GetAllAppointmentsAsync()
        {
            await Task.Delay(500);
            var appointments = await _context.Appointments.ToListAsync();
            return appointments;
        }

        // This is the method that gets all notes belonging to the specific userId
        public async Task<List<Appointment>> GetAppointmentsByUserIdAsync (string userId)
        {
            await Task.Delay(500);
            return await _context.Appointments
                .Where(a => a.User.Id == userId)
                .ToListAsync();
        }


        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            return appointment;
        }

        public async Task AddAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAppointmentAsync(int id, string userId)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAppointmentAsync(Appointment appointment, int id)
        {
            var dbAppointment = await _context.Appointments.FindAsync(id);
            if (dbAppointment != null)
            {
                dbAppointment.Subject = appointment.Subject;
                dbAppointment.Description = appointment.Description;
                dbAppointment.StartTime = appointment.StartTime;
                dbAppointment.EndTime = appointment.EndTime;
                dbAppointment.Location = appointment.Location;
                dbAppointment.IsAllDay = appointment.IsAllDay;
                dbAppointment.RecurrenceRule = appointment.RecurrenceRule;
                dbAppointment.RecurrenceException = appointment.RecurrenceException;
                dbAppointment.RecurrenceId = appointment.RecurrenceId;

                await _context.SaveChangesAsync();
            }
        }
    }
}

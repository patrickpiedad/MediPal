using MediPal.Data;
using MediPal.Models;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor.Schedule;
using System.Collections.ObjectModel;

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
            //await Task.Delay(500);
            List<Appointment> appointments = await _context.Appointments.ToListAsync();
            return appointments;
        }

        // This is the method that gets all notes belonging to the specific userId
        public async Task<List<Appointment>> GetAppointmentsByUserIdAsync(string userId)
        {
            //await Task.Delay(500);
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
            await _context.Appointments.AddAsync(appointment);
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
            var dbAppointment = await _context.Appointments.FirstAsync(c => c.AppointmentId == appointment.AppointmentId);

            if (appointment != null)
            {
                dbAppointment.UserId = appointment.UserId;
                dbAppointment.Subject = appointment.Subject;
                dbAppointment.StartTime = appointment.StartTime;
                dbAppointment.EndTime = appointment.EndTime;
                dbAppointment.StartTimezone = appointment.StartTimezone;
                dbAppointment.EndTimezone = appointment.EndTimezone;
                dbAppointment.Location = appointment.Location;
                dbAppointment.Description = appointment.Description;
                dbAppointment.IsAllDay = appointment.IsAllDay;
                dbAppointment.RecurrenceId = appointment.RecurrenceId;
                dbAppointment.RecurrenceRule = appointment.RecurrenceRule;
                dbAppointment.RecurrenceException = appointment.RecurrenceException;

                dbAppointment.IsReadOnly = appointment.IsReadOnly;
                dbAppointment.IsBlock = appointment.IsBlock;

                await _context.SaveChangesAsync();
            }
        }
    }
}

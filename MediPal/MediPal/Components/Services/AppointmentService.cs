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
            //await Task.Delay(500);
            var appointments = await _context.Appointments.ToListAsync();
            return appointments;
        }

        // This is the method that gets all notes belonging to the specific userId
        public async Task<List<Appointment>> GetAppointmentsByUserIdAsync (string userId)
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
            //var app = new Appointment();
            //app.Subject = appointment.Subject;
            //app.StartTime = appointment.StartTime;
            //app.EndTime = appointment.EndTime;
            //app.StartTimezone = appointment.StartTimezone;
            //app.EndTimezone = appointment.EndTimezone;
            //app.Location = appointment.Location;
            //app.Description = appointment.Description;
            //app.IsReadOnly = appointment.IsReadOnly;
            //app.IsAllDay = appointment.IsAllDay;
            //app.RecurrenceId = appointment.RecurrenceId;
            //app.RecurrenceRule = appointment.RecurrenceRule;
            //app.RecurrenceException = appointment.RecurrenceException;
            //app.IsBlock = appointment.IsBlock;

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
            var app = await _context.Appointments.FindAsync(id);
            if (app != null)
            {
                app.StartTime = appointment.StartTime;
                app.EndTime = appointment.EndTime;
                app.StartTimezone = appointment.StartTimezone;
                app.EndTimezone = appointment.EndTimezone;
                app.Location = appointment.Location;
                app.Description = appointment.Description;
                app.IsReadOnly = appointment.IsReadOnly;
                app.IsAllDay = appointment.IsAllDay;
                app.RecurrenceId = appointment.RecurrenceId;
                app.RecurrenceRule = appointment.RecurrenceRule;
                app.RecurrenceException = appointment.RecurrenceException;
                app.IsBlock = appointment.IsBlock;

                //_context.Appointments.Update(app);
                await _context.SaveChangesAsync();
            }
        }
    }
}

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
            //check this and determine where to build appointment based on the syncfusion schedule requirements
            var app = new Appointment();
            app.UserId = appointment.UserId;
            app.Subject = appointment.Subject;
            app.StartTime = appointment.StartTime;
            app.EndTime = appointment.EndTime;
            app.StartTimezone = appointment.StartTimezone;
            app.EndTimezone = appointment.EndTimezone;
            app.Location = appointment.Location;
            app.Description = appointment.Description;
            app.IsAllDay = appointment.IsAllDay;
            app.RecurrenceId = appointment.RecurrenceId;
            app.RecurrenceRule = appointment.RecurrenceRule;
            app.RecurrenceException = appointment.RecurrenceException;

            app.IsReadOnly = appointment.IsReadOnly;
            app.IsBlock = appointment.IsBlock;

            await _context.Appointments.AddAsync(app);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAppointmentAsync(Appointment appointment)
        {
            var app = await _context.Appointments.FirstAsync(a => a.UserId == appointment.UserId);

            if (app != null)
            {
                _context.Appointments?.Remove(app);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            var app = await _context.Appointments.FirstAsync(c => c.AppointmentId == appointment.AppointmentId);

            if (app != null)
            {
                app.UserId = appointment.UserId;
                app.Subject = appointment.Subject;
                app.StartTime = appointment.StartTime;
                app.EndTime = appointment.EndTime;
                app.StartTimezone = appointment.StartTimezone;
                app.EndTimezone = appointment.EndTimezone;
                app.Location = appointment.Location;
                app.Description = appointment.Description;
                app.IsAllDay = appointment.IsAllDay;
                app.RecurrenceId = appointment.RecurrenceId;
                app.RecurrenceRule = appointment.RecurrenceRule;
                app.RecurrenceException = appointment.RecurrenceException;
                
                app.IsReadOnly = appointment.IsReadOnly;
                app.IsBlock = appointment.IsBlock;

                _context.Appointments?.Update(app);
                await _context.SaveChangesAsync();
            }
        }
    }
}

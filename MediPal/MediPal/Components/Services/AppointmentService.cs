﻿using MediPal.Data;
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

            // Detach the appointment to avoid multiple tracked instances
            _context.Entry(appointment).State = EntityState.Detached;
        }



        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            // Old dbAppointment fetch before working multiple instance tracking error
            //var dbAppointment = await _context.Appointments.FindAsync(appointment.AppointmentId);

            var dbAppointment = await _context.Appointments
                .Include(a => a.User) // Include the User entity
                .FirstOrDefaultAsync(c => c.AppointmentId == appointment.AppointmentId);

            if (dbAppointment != null)
            {

                // Fetch the existing tracked user from the database to avoid duplicate tracking
                var existingUser = await _context.Users
                        .FirstOrDefaultAsync(u => u.Id == appointment.UserId);

                if (existingUser != null)
                {
                    // Detach the old user entity from the context, so we can attach the new one
                    _context.Entry(dbAppointment.User).State = EntityState.Detached;

                    // Assign the existing user instance
                    dbAppointment.User = existingUser;
                }

                if (appointment != null)
                {

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

        public async Task DeleteAppointmentAsync(int id, string userId)
        {
            var dbAppointment = await _context.Appointments.FindAsync(id);

            if (dbAppointment != null)
            {
                _context.Appointments.Remove(dbAppointment);
                await _context.SaveChangesAsync();
            }
        }
    }
}

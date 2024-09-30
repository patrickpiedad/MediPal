using MediPal.Models;
using Microsoft.AspNetCore.Identity;

namespace MediPal.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Gender { get; set; }

        public DateOnly DateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public virtual ICollection<Symptom>? Symptoms { get; set; }

        public virtual ICollection<Note>? Notes { get; set; }

        public virtual ICollection<Appointment>? Appointments { get; set; }
    }

}





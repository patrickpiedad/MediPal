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

        //public string? MedicalDiagnosis { get; set; }
    }

}





using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using MediPal.Models;
using MediPal.Components.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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





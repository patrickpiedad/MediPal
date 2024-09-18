using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MediPal.Data;
using Microsoft.AspNetCore.Identity;
using MediPal.Components.Services;

namespace MediPal.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Patient name cannot exceed 100 characters.")]
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required]
        public string? Gender { get; set; }

        [Required]
        public DateOnly DateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        //[Required]
        //[StringLength(100, ErrorMessage = "Medical diagnosis cannot exceed 100 characters.")]
        //public string? MedicalDiagnosis { get; set; }

        public int? Age { get; set; }

        //public ICollection<Symptom>? Symptoms { get; set; } //Adding a collection of symptoms to the patient table?



    }
}

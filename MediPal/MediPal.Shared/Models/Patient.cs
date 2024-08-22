using System.ComponentModel.DataAnnotations;

namespace MediPal.Shared.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Patient name cannot exceed 100 characters.")]
        public string? PatientName { get; set; }

        [Required]
        public string? PatientGender { get; set; }

        [Required]
        public DateOnly DateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Required]
        [StringLength(100, ErrorMessage = "Medical diagnosis cannot exceed 100 characters.")]
        public string? MedicalDiagnosis { get; set; }

        public int? Age { get; set; }
    
        //public int? CalculateAge(DateOnly DateOfBirth)
        //{
        //    Age = DateOnly.FromDateTime(DateTime.Now) - DateOfBirth;
        //    return Age;
        //}

    
    }
}

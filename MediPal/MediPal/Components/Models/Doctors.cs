using System.ComponentModel.DataAnnotations;

namespace MediPal.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Patient name cannot exceed 100 characters.")]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public DateOnly DateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Required]
        [StringLength(100, ErrorMessage = "Role cannot exceed 100 characters.")]

        public string? Title { get; set; }
        public string? Role { get; set; }

        public int? Age { get; set; }

        public Doctor ()
        {
            FirstName = "";
            LastName = "";
            DateOfBirth = DateOnly.FromDateTime(DateTime.Now);
            Role = "";
        }
        public Doctor (string FirstName, string LastName, DateOnly DateOfBirth, string Title, string Role)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Title = Title;
            this.Role = Role;
        }

    }
}

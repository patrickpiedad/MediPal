using MediPal.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediPal.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Location {get; set;}

        public bool IsAllDay { get; set; }

        public string RecurrenceRule { get; set; }
        
        public string RecurrenceException { get; set; }

        public Nullable<int> RecurrenceId { get; set; }

        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}

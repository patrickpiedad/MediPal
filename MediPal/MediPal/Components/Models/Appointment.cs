using MediPal.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediPal.Models
{
    public class Appointment : INotifyPropertyChanged
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required]
        public string? Subject { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string? StartTimezone { get; set; }

        public string? EndTimezone { get; set; }

        public string? Location { get; set; }

        public string? Description { get; set; }

        public bool IsAllDay { get; set; }

        public Nullable<int> RecurrenceId { get; set; }

        public string? RecurrenceRule { get; set; }

        public string? RecurrenceException { get; set; }

        public bool? IsReadOnly { get; set; }

        public bool? IsBlock { get; set; }

        // INotifyProperty Interface Implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // Link to user class for foreign keys
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }


    }
}

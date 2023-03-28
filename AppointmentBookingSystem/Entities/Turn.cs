using System.ComponentModel.DataAnnotations;

namespace AppointmentBookingSystem.Entities
{
    public class Turn
    {
        [Key]
        public int Id { get; set; }
        public int ServiceId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }
        public Service Service { get; set; }
    }
}

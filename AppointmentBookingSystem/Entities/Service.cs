using System.ComponentModel.DataAnnotations;

namespace AppointmentBookingSystem.Entities
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public int ComerceId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public TimeSpan OpeningHour { get; set; }
        [Required]
        public TimeSpan ClosingTime { get; set; }
        [Required]
        public int Duration { get; set; }
        public Store Store { get; set; }
        public ICollection<Turn> Turns { get; set; }

    }
}

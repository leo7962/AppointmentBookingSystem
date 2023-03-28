using System.ComponentModel.DataAnnotations;

namespace AppointmentBookingSystem.Entities
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int Capacity { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}

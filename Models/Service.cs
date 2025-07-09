using System.ComponentModel.DataAnnotations;

namespace SalonBookingApp.Models
{
    // This class represents a service offered by the salon
    public class Service
    {
        [Key]
        public int ServiceId { get; set; } // Primary key

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; } // Name of the service (e.g., Haircut)

        [MaxLength(250)]
        public string? Description { get; set; } // Description of the service

        [Required]
        public decimal Price { get; set; } // Price of the service
    }
} 
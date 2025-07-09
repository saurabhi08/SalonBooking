using System.ComponentModel.DataAnnotations;

namespace SalonBookingApp.Models
{
    // This class represents a stylist who works at the salon
    public class Stylist
    {
        [Key]
        public int StylistId { get; set; } // Primary key

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; } // Stylist's full name

        [MaxLength(100)]
        public string? Specialty { get; set; } // Stylist's area of expertise
    }
} 
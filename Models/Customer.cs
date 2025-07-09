using System.ComponentModel.DataAnnotations;

namespace SalonBookingApp.Models
{
    // This class represents a customer in the salon booking system
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; } // Primary key

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; } // Customer's full name

        [Required]
        [EmailAddress]
        public string? Email { get; set; } // Customer's email address

        [Phone]
        public string? Phone { get; set; } // Customer's phone number
    }
} 
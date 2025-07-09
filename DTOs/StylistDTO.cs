namespace SalonBookingApp.DTOs
{
    // Data Transfer Object for Stylist
    public class StylistDTO
    {
        public int StylistId { get; set; } // Stylist's unique ID
        public string? Name { get; set; } // Stylist's name
        public string? Specialty { get; set; } // Stylist's specialty
    }
} 
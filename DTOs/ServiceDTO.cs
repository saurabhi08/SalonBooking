namespace SalonBookingApp.DTOs
{
    // Data Transfer Object for Service
    public class ServiceDTO
    {
        public int ServiceId { get; set; } // Service's unique ID
        public string? Name { get; set; } // Name of the service
        public string? Description { get; set; } // Description of the service
        public decimal Price { get; set; } // Price of the service
    }
} 
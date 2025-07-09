namespace SalonBookingApp.DTOs
{
    // Data Transfer Object for Customer
    public class CustomerDTO
    {
        public int CustomerId { get; set; } // Customer's unique ID
        public string? Name { get; set; } // Customer's name
        public string? Email { get; set; } // Customer's email
        public string? Phone { get; set; } // Customer's phone
    }
} 
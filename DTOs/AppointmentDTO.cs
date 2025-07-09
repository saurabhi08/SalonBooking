using System;

namespace SalonBookingApp.DTOs
{
    // Data Transfer Object for Appointment
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; } // Appointment's unique ID
        public DateTime Date { get; set; } // Date and time of the appointment
        public int CustomerId { get; set; } // Customer's ID
        public string? CustomerName { get; set; } // Customer's name
        public int StylistId { get; set; } // Stylist's ID
        public string? StylistName { get; set; } // Stylist's name
        public int ServiceId { get; set; } // Service's ID
        public string? ServiceName { get; set; } // Service's name
    }
} 
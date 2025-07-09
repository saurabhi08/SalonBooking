using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalonBookingApp.Models
{
    // This class represents an appointment booked by a customer
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; } // Primary key

        [Required]
        public DateTime Date { get; set; } // Date and time of the appointment

        // Foreign key to Customer
        [Required]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        // Foreign key to Stylist
        [Required]
        public int StylistId { get; set; }
        [ForeignKey("StylistId")]
        public Stylist? Stylist { get; set; }

        // Foreign key to Service
        [Required]
        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Service? Service { get; set; }
    }
} 
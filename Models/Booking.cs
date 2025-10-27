using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieBookingSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }
        
        [Required]
        public int UserId { get; set; }
        
        [Required]
        public int ShowtimeId { get; set; }
        
        [Required]
        [Range(1, 10, ErrorMessage = "Number of tickets must be between 1 and 10")]
        [Display(Name = "Number of Tickets")]
        public int NumberOfTickets { get; set; }
        
        [Required]
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }
        
        public string Seats { get; set; } = string.Empty;
        
        [Required]
        public string Status { get; set; } = "Confirmed";
        
        public DateTime BookingDate { get; set; } = DateTime.Now;
        
        public string BookingReference { get; set; } = string.Empty;
        
        // Navigation properties
        public virtual User? User { get; set; }
        public virtual Showtime? Showtime { get; set; }
    }
}
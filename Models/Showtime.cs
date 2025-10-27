using System.ComponentModel.DataAnnotations;

namespace MovieBookingSystem.Models
{
    public class Showtime
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Movie is required")]
        [Display(Name = "Movie")]
        public int MovieId { get; set; }
        
        [Required(ErrorMessage = "Show date and time is required")]
        [Display(Name = "Show Date & Time")]
        public DateTime ShowDateTime { get; set; }
        
        [Required(ErrorMessage = "Theater name is required")]
        public string Theater { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Total seats is required")]
        [Range(1, 500, ErrorMessage = "Seats must be between 1 and 500")]
        [Display(Name = "Total Seats")]
        public int TotalSeats { get; set; }
        
        public int AvailableSeats { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        // Navigation property
        public virtual Movie? Movie { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        // Method to update available seats automatically
        public void UpdateAvailableSeats()
        {
            var confirmedBookingsCount = Bookings?
                .Where(b => b.Status == "Confirmed")
                .Sum(b => b.NumberOfTickets) ?? 0;
                
            AvailableSeats = TotalSeats - confirmedBookingsCount;
            
            // Deactivate showtime if no seats available or showtime passed
            if (AvailableSeats <= 0 || ShowDateTime < DateTime.Now)
            {
                IsActive = false;
            }
        }
    }
}
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieBookingSystem.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Movie title is required")]
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }
        
        [Required(ErrorMessage = "Duration is required")]
        public TimeSpan Duration { get; set; }
        
        [Required(ErrorMessage = "Language is required")]
        public string Language { get; set; }
        
        public string ImageUrl { get; set; } = "/images/default-movie.jpg";
        
        [Required(ErrorMessage = "Release date is required")]
        public DateTime ReleaseDate { get; set; }
        
        [Required(ErrorMessage = "Ticket price is required")]
        [Range(0.01, 1000, ErrorMessage = "Price must be between 0.01 and 1000")]
        public decimal TicketPrice { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        
        // Image upload property (NOT mapped to database)
        [NotMapped] // ✅ This tells EF to ignore this property
        [Display(Name = "Movie Poster")]
        public IFormFile? ImageFile { get; set; }
        
        public virtual ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
    }
}
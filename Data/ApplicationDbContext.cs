using Microsoft.EntityFrameworkCore;
using MovieBookingSystem.Models;

namespace MovieBookingSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Showtime> Showtimes { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships for MySQL
            modelBuilder.Entity<Showtime>()
                .HasOne(s => s.Movie)
                .WithMany(m => m.Showtimes)
                .HasForeignKey(s => s.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Showtime)
                .WithMany(s => s.Bookings)
                .HasForeignKey(b => b.ShowtimeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed admin user
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Admin User",
                    Email = "admin@moviebook.com",
                    Password = "admin123",
                    Phone = "1234567890",
                    IsAdmin = true,
                    CreatedAt = new DateTime(2024, 1, 1)
                }
            );

            // Seed sample movies with Indian prices
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Avengers: Endgame",
                    Description = "The epic conclusion to the Infinity Saga.",
                    Genre = "Action",
                    Duration = new TimeSpan(3, 1, 0),
                    Language = "English",
                    ImageUrl = "/images/avengers.jpg",
                    ReleaseDate = new DateTime(2019, 4, 26),
                    TicketPrice = 280m, // ₹280
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1)
                },
                new Movie
                {
                    Id = 2,
                    Title = "Spider-Man: No Way Home",
                    Description = "Spider-Man identity revealed with multiverse.",
                    Genre = "Action",
                    Duration = new TimeSpan(2, 28, 0),
                    Language = "English",
                    ImageUrl = "/images/spiderman.jpg",
                    ReleaseDate = new DateTime(2021, 12, 17),
                    TicketPrice = 250m, // ₹250
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1)
                },
                new Movie
                {
                    Id = 3,
                    Title = "The Batman",
                    Description = "Dark knight investigation in Gotham city.",
                    Genre = "Action",
                    Duration = new TimeSpan(2, 56, 0),
                    Language = "English",
                    ImageUrl = "/images/batman.jpg",
                    ReleaseDate = new DateTime(2022, 3, 4),
                    TicketPrice = 220m, // ₹220
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1)
                },
                new Movie
                {
                    Id = 4,
                    Title = "RRR",
                    Description = "A fictional story about two Indian revolutionaries.",
                    Genre = "Action/Drama",
                    Duration = new TimeSpan(3, 7, 0),
                    Language = "Hindi/Telugu",
                    ImageUrl = "/images/rrr.jpg",
                    ReleaseDate = new DateTime(2022, 3, 25),
                    TicketPrice = 200m, // ₹200
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1)
                },
                new Movie
                {
                    Id = 5,
                    Title = "KGF Chapter 2",
                    Description = "Rocky continues his rise to power in the gold mining world.",
                    Genre = "Action",
                    Duration = new TimeSpan(2, 48, 0),
                    Language = "Hindi/Kannada",
                    ImageUrl = "/images/kgf2.jpg",
                    ReleaseDate = new DateTime(2022, 4, 14),
                    TicketPrice = 180m, // ₹180
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1)
                }
            );

            // Seed sample showtimes
            modelBuilder.Entity<Showtime>().HasData(
                new Showtime
                {
                    Id = 1,
                    MovieId = 1,
                    ShowDateTime = DateTime.Now.AddDays(1).AddHours(18).AddMinutes(30),
                    Theater = "PVR Cinemas - Forum Mall",
                    TotalSeats = 150,
                    AvailableSeats = 150,
                    IsActive = true
                },
                new Showtime
                {
                    Id = 2,
                    MovieId = 2,
                    ShowDateTime = DateTime.Now.AddHours(2),
                    Theater = "INOX - Magnolia Mall",
                    TotalSeats = 120,
                    AvailableSeats = 120,
                    IsActive = true
                },
                new Showtime
                {
                    Id = 3,
                    MovieId = 3,
                    ShowDateTime = DateTime.Now.AddDays(2).AddHours(20).AddMinutes(0),
                    Theater = "Cinepolis - Urban Center",
                    TotalSeats = 100,
                    AvailableSeats = 100,
                    IsActive = true
                },
                new Showtime
                {
                    Id = 4,
                    MovieId = 4,
                    ShowDateTime = DateTime.Now.AddDays(1).AddHours(15).AddMinutes(0),
                    Theater = "PVR Cinemas - Phoenix Mall",
                    TotalSeats = 200,
                    AvailableSeats = 200,
                    IsActive = true
                },
                new Showtime
                {
                    Id = 5,
                    MovieId = 5,
                    ShowDateTime = DateTime.Now.AddDays(3).AddHours(21).AddMinutes(0),
                    Theater = "INOX - Nexus Mall",
                    TotalSeats = 180,
                    AvailableSeats = 180,
                    IsActive = true
                }
            );
        }
    }
}
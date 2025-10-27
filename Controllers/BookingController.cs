using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieBookingSystem.Data;
using MovieBookingSystem.Models;

namespace MovieBookingSystem.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> BookShowtime(int id)
        {
            if (!IsUserLoggedIn())
            {
                TempData["ErrorMessage"] = "Please login to book tickets.";
                return RedirectToAction("Login", "Account");
            }

            var showtime = await _context.Showtimes
                .Include(s => s.Movie)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (showtime == null || !showtime.IsActive || showtime.ShowDateTime < DateTime.Now)
            {
                TempData["ErrorMessage"] = "Showtime not available for booking.";
                return RedirectToAction("Index", "Home");
            }

            // ✅ Simple seat categories - Database change nahi karna
            var seatCategories = new[]
            {
                new { Name = "Premium", Price = showtime.Movie.TicketPrice + 50, Description = "Front rows with best view" },
                new { Name = "Standard", Price = showtime.Movie.TicketPrice, Description = "Comfortable seating" },
                new { Name = "Economy", Price = showtime.Movie.TicketPrice - 20, Description = "Budget friendly" }
            };

            ViewBag.Showtime = showtime;
            ViewBag.SeatCategories = seatCategories;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookShowtime(int showtimeId, string seatCategory, int numberOfTickets)
        {
            if (!IsUserLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }

            var showtime = await _context.Showtimes
                .Include(s => s.Movie)
                .FirstOrDefaultAsync(s => s.Id == showtimeId);

            if (showtime == null || !showtime.IsActive)
            {
                TempData["ErrorMessage"] = "Showtime not available.";
                return RedirectToAction("Index", "Home");
            }

            if (showtime.AvailableSeats < numberOfTickets)
            {
                TempData["ErrorMessage"] = $"Only {showtime.AvailableSeats} seats available.";
                return RedirectToAction("BookShowtime", new { id = showtimeId });
            }

            if (numberOfTickets < 1 || numberOfTickets > 10)
            {
                TempData["ErrorMessage"] = "You can book 1 to 10 tickets only.";
                return RedirectToAction("BookShowtime", new { id = showtimeId });
            }

            // ✅ Price calculation based on seat category
            decimal finalPrice = showtime.Movie.TicketPrice;
            if (seatCategory == "Premium") finalPrice += 50;
            else if (seatCategory == "Economy") finalPrice -= 20;

            var userId = HttpContext.Session.GetInt32("UserId") ?? 0;

            var newBooking = new Booking
            {
                UserId = userId,
                ShowtimeId = showtimeId,
                NumberOfTickets = numberOfTickets,
                TotalAmount = numberOfTickets * finalPrice,
                Seats = GenerateSeats(numberOfTickets),
                BookingDate = DateTime.Now,
                Status = "Confirmed",
                BookingReference = GenerateBookingReference()
            };

            showtime.AvailableSeats -= numberOfTickets;

            _context.Bookings.Add(newBooking);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Booking confirmed! Reference: {newBooking.BookingReference}";
            return RedirectToAction("BookingConfirmation", new { id = newBooking.Id });
        }

        public async Task<IActionResult> BookingConfirmation(int id)
        {
            if (!IsUserLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }

            var booking = await _context.Bookings
                .Include(b => b.Showtime)
                .ThenInclude(s => s.Movie)
                .Include(b => b.User)
                .FirstOrDefaultAsync(b => b.Id == id);

            var userId = HttpContext.Session.GetInt32("UserId") ?? 0;

            if (booking == null || booking.UserId != userId)
            {
                TempData["ErrorMessage"] = "Booking not found.";
                return RedirectToAction("MyBookings");
            }

            return View(booking);
        }

        public async Task<IActionResult> MyBookings()
        {
            if (!IsUserLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }

            var userId = HttpContext.Session.GetInt32("UserId") ?? 0;

            var bookings = await _context.Bookings
                .Include(b => b.Showtime)
                .ThenInclude(s => s.Movie)
                .Where(b => b.UserId == userId)
                .OrderByDescending(b => b.BookingDate)
                .ToListAsync();

            return View(bookings);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelBooking(int id)
        {
            if (!IsUserLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }

            var userId = HttpContext.Session.GetInt32("UserId") ?? 0;

            var booking = await _context.Bookings
                .Include(b => b.Showtime)
                .FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId);

            if (booking == null || booking.Status != "Confirmed")
            {
                TempData["ErrorMessage"] = "Booking cannot be cancelled.";
                return RedirectToAction("MyBookings");
            }

            booking.Showtime.AvailableSeats += booking.NumberOfTickets;
            booking.Status = "Cancelled";

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Booking cancelled successfully.";
            return RedirectToAction("MyBookings");
        }

        private bool IsUserLoggedIn()
        {
            return HttpContext.Session.GetInt32("UserId") != null;
        }

        private string GenerateBookingReference()
        {
            return "BK" + DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(1000, 9999);
        }

        private string GenerateSeats(int numberOfTickets)
        {
            var rows = new[] { "A", "B", "C", "D", "E", "F" };
            var startSeat = new Random().Next(1, 15);
            var row = rows[new Random().Next(0, rows.Length)];

            var seats = new List<string>();
            for (int i = 0; i < numberOfTickets; i++)
            {
                seats.Add($"{row}{startSeat + i}");
            }

            return string.Join(", ", seats);
        }
    }
}
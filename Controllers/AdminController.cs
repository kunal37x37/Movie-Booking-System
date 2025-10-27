using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieBookingSystem.Data;
using MovieBookingSystem.Models;

namespace MovieBookingSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public AdminController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> AdminDashboard()
        {
            if (!IsAdmin())
            {
                TempData["ErrorMessage"] = "Access denied. Admin privileges required.";
                return RedirectToAction("Login", "Account");
            }

            var confirmedBookings = await _context.Bookings
                .Where(b => b.Status == "Confirmed")
                .ToListAsync();

            decimal totalRevenue = 0;
            foreach (var booking in confirmedBookings)
            {
                totalRevenue += booking.TotalAmount;
            }

            var dashboard = new AdminDashboardViewModel
            {
                TotalMovies = await _context.Movies.CountAsync(),
                TotalBookings = await _context.Bookings.CountAsync(),
                TotalUsers = await _context.Users.CountAsync(u => !u.IsAdmin),
                TotalRevenue = totalRevenue,
                RecentBookings = await _context.Bookings
                    .Include(b => b.User)
                    .Include(b => b.Showtime)
                    .ThenInclude(s => s.Movie)
                    .OrderByDescending(b => b.BookingDate)
                    .Take(10)
                    .ToListAsync(),
                PendingBookings = await _context.Bookings
                    .Where(b => b.Status == "Confirmed")
                    .CountAsync()
            };

            return View(dashboard);
        }

        // MOVIES MANAGEMENT
        public async Task<IActionResult> Movies()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }

            var movies = await _context.Movies
                .OrderByDescending(m => m.CreatedAt)
                .ToListAsync();

            return View(movies);
        }

        public IActionResult AddMovie()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMovie(Movie movie)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Image upload handling - FIXED: Added null check
                    if (movie.ImageFile != null && movie.ImageFile.Length > 0)
                    {
                        var imageUrl = await SaveImage(movie.ImageFile);
                        movie.ImageUrl = imageUrl;
                    }
                    else
                    {
                        movie.ImageUrl = "/images/default-movie.jpg";
                    }

                    movie.CreatedAt = DateTime.Now;
                    movie.IsActive = true;
                    
                    _context.Movies.Add(movie);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Movie added successfully with image!";
                    return RedirectToAction("Movies");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error adding movie: {ex.Message}";
                }
            }

            return View(movie);
        }

        // EDIT MOVIE - GET
        public async Task<IActionResult> EditMovie(int id)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                TempData["ErrorMessage"] = "Movie not found.";
                return RedirectToAction("Movies");
            }

            return View(movie);
        }

        // EDIT MOVIE - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMovie(int id, Movie movie)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }

            if (id != movie.Id)
            {
                TempData["ErrorMessage"] = "Movie ID mismatch.";
                return RedirectToAction("Movies");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingMovie = await _context.Movies.FindAsync(id);
                    if (existingMovie == null)
                    {
                        TempData["ErrorMessage"] = "Movie not found.";
                        return RedirectToAction("Movies");
                    }

                    // Image upload handling for edit - FIXED: Added null check
                    if (movie.ImageFile != null && movie.ImageFile.Length > 0)
                    {
                        // Delete old image if it's not default
                        if (!string.IsNullOrEmpty(existingMovie.ImageUrl) && 
                            !existingMovie.ImageUrl.Contains("default-movie"))
                        {
                            DeleteImage(existingMovie.ImageUrl);
                        }
                        
                        var imageUrl = await SaveImage(movie.ImageFile);
                        existingMovie.ImageUrl = imageUrl;
                    }

                    // Update other properties
                    existingMovie.Title = movie.Title;
                    existingMovie.Description = movie.Description;
                    existingMovie.Genre = movie.Genre;
                    existingMovie.Duration = movie.Duration;
                    existingMovie.Language = movie.Language;
                    existingMovie.ReleaseDate = movie.ReleaseDate;
                    existingMovie.TicketPrice = movie.TicketPrice;
                    existingMovie.IsActive = movie.IsActive;

                    _context.Movies.Update(existingMovie);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Movie updated successfully!";
                    return RedirectToAction("Movies");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(id))
                    {
                        TempData["ErrorMessage"] = "Movie not found.";
                        return RedirectToAction("Movies");
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error updating movie: {ex.Message}";
                }
            }

            return View(movie);
        }

        // DELETE MOVIE - GET (Confirmation Page)
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }

            var movie = await _context.Movies
                .Include(m => m.Showtimes)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                TempData["ErrorMessage"] = "Movie not found.";
                return RedirectToAction("Movies");
            }

            return View(movie);
        }

        // DELETE MOVIE - POST (Actual Delete)
        [HttpPost, ActionName("DeleteMovie")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMovieConfirmed(int id)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }

            var movie = await _context.Movies
                .Include(m => m.Showtimes)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                TempData["ErrorMessage"] = "Movie not found.";
                return RedirectToAction("Movies");
            }

            try
            {
                // Delete associated image
                if (!string.IsNullOrEmpty(movie.ImageUrl) && !movie.ImageUrl.Contains("default-movie"))
                {
                    DeleteImage(movie.ImageUrl);
                }

                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Movie deleted successfully!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting movie: {ex.Message}";
            }

            return RedirectToAction("Movies");
        }

        // TOGGLE MOVIE STATUS
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleMovieStatus(int id)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                TempData["ErrorMessage"] = "Movie not found.";
                return RedirectToAction("Movies");
            }

            movie.IsActive = !movie.IsActive;
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Movie {(movie.IsActive ? "activated" : "deactivated")} successfully!";
            return RedirectToAction("Movies");
        }

        // SHOWTIMES MANAGEMENT
        public async Task<IActionResult> Showtimes()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }

            var showtimes = await _context.Showtimes
                .Include(s => s.Movie)
                .OrderBy(s => s.ShowDateTime)
                .ToListAsync();

            return View(showtimes);
        }

        public async Task<IActionResult> AddShowtime()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Movies = await _context.Movies
                .Where(m => m.IsActive)
                .OrderBy(m => m.Title)
                .ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddShowtime(Showtime showtime)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                if (showtime.ShowDateTime < DateTime.Now)
                {
                    ModelState.AddModelError("ShowDateTime", "Showtime must be in the future.");
                    ViewBag.Movies = await _context.Movies.Where(m => m.IsActive).ToListAsync();
                    return View(showtime);
                }

                showtime.AvailableSeats = showtime.TotalSeats;
                showtime.IsActive = true;

                _context.Showtimes.Add(showtime);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Showtime added successfully!";
                return RedirectToAction("Showtimes");
            }

            ViewBag.Movies = await _context.Movies.Where(m => m.IsActive).ToListAsync();
            return View(showtime);
        }

        // DELETE SHOWTIME
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteShowtime(int id)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }

            var showtime = await _context.Showtimes
                .Include(s => s.Bookings)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (showtime == null)
            {
                TempData["ErrorMessage"] = "Showtime not found.";
                return RedirectToAction("Showtimes");
            }

            try
            {
                // Check if showtime has bookings - FIXED: Added null check
                if (showtime.Bookings != null && showtime.Bookings.Any(b => b.Status == "Confirmed"))
                {
                    TempData["ErrorMessage"] = "Cannot delete showtime with confirmed bookings.";
                    return RedirectToAction("Showtimes");
                }

                _context.Showtimes.Remove(showtime);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Showtime deleted successfully!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting showtime: {ex.Message}";
            }

            return RedirectToAction("Showtimes");
        }

        // TOGGLE SHOWTIME STATUS
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleShowtimeStatus(int id)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }

            var showtime = await _context.Showtimes.FindAsync(id);
            if (showtime == null)
            {
                TempData["ErrorMessage"] = "Showtime not found.";
                return RedirectToAction("Showtimes");
            }

            showtime.IsActive = !showtime.IsActive;
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Showtime {(showtime.IsActive ? "activated" : "deactivated")} successfully!";
            return RedirectToAction("Showtimes");
        }

        public async Task<IActionResult> AllBookings()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }

            var bookings = await _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Showtime)
                .ThenInclude(s => s.Movie)
                .OrderByDescending(b => b.BookingDate)
                .ToListAsync();

            return View(bookings);
        }

        public async Task<IActionResult> Users()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }

            var users = await _context.Users
                .Where(u => !u.IsAdmin)
                .OrderByDescending(u => u.CreatedAt)
                .ToListAsync();

            return View(users);
        }

        // IMAGE UPLOAD HELPER METHODS
        private async Task<string> SaveImage(IFormFile imageFile)
        {
            try
            {
                // Create images directory if not exists
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "images", "movies");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Generate unique filename
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Save image
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }

                // Return relative path
                return $"/images/movies/{uniqueFileName}";
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error saving image: {ex.Message}");
                return "/images/default-movie.jpg";
            }
        }

        private void DeleteImage(string imageUrl)
        {
            try
            {
                if (!string.IsNullOrEmpty(imageUrl) && !imageUrl.Contains("default-movie"))
                {
                    var filePath = Path.Combine(_environment.WebRootPath, imageUrl.TrimStart('/'));
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error deleting image: {ex.Message}");
            }
        }

        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("IsAdmin") == "True";
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }

    public class AdminDashboardViewModel
    {
        public int TotalMovies { get; set; }
        public int TotalBookings { get; set; }
        public int TotalUsers { get; set; }
        public decimal TotalRevenue { get; set; }
        public int PendingBookings { get; set; }
        public List<Booking> RecentBookings { get; set; } = new List<Booking>();
    }
}
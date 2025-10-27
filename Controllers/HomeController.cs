using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieBookingSystem.Data;
using MovieBookingSystem.Models;

namespace MovieBookingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _context.Movies
                .Where(m => m.IsActive)
                .OrderByDescending(m => m.ReleaseDate)
                .ToListAsync();
            return View(movies);
        }

        public async Task<IActionResult> MovieDetails(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.Showtimes)
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync();

            if (movie == null)
            {
                return NotFound();
            }

            // Filter active showtimes
            movie.Showtimes = movie.Showtimes
                .Where(s => s.ShowDateTime >= DateTime.Now && s.IsActive && s.AvailableSeats > 0)
                .OrderBy(s => s.ShowDateTime)
                .ToList();

            return View(movie);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
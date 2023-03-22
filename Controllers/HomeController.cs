using Microsoft.AspNetCore.Mvc;
using MusicSystem.Data;
using MusicSystem.Models;
using System.Diagnostics;

namespace MusicSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBContext _context;

        public HomeController(ILogger<HomeController> logger, DBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            if (_context.Song.Any(s => s.SongContributors == null))
            {
                ViewBag.ErrorMessage = "All Songs must have an associated Album and Artist";
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using ECMTricket.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ECMTricket.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _context.Movies.Include(c => c.Cinema).OrderBy(m => m.Name).ToListAsync();
            return View(movies);
        }

        public async Task<IActionResult> Filter(string filter)
        {
            return View();
        }
    }
}

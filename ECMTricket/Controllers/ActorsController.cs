using ECMTricket.Data;
using ECMTricket.Data.Services;
using ECMTricket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ECMTricket.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _actorsService;

        public ActorsController(IActorsService actorsService)
        {
            _actorsService = actorsService;
        }

        public async Task<IActionResult> Index()
        {            
            var actors = await _actorsService.GetAll();
            return View(actors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL, FullName, Bio")] Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);
            }
            await _actorsService.Add(actor);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detials(int id)
        {
            var actorDetial = await _actorsService.GetById(id);

            if (actorDetial == null) return View("NotFound");

            return View(actorDetial);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var actor = await _actorsService.GetById(id);

            if (actor == null) return View("NotFound");

            return View(actor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL, FullName, Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _actorsService.Update(id, actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var actor = await _actorsService.GetById(id);

            if (actor == null) return View("NotFound");

            return View(actor);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actor = await _actorsService.GetById(id);

            if (actor == null) return View("NotFound");

            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _actorsService.Delete(actor);

            return RedirectToAction(nameof(Index));
        }
    }
}

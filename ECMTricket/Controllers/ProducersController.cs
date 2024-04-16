using ECMTricket.Data;
using ECMTricket.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ECMTricket.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerService _service;

        public ProducersController(IProducerService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var producers = await _service.GetAll();
            return View(producers);
        }
    }
}

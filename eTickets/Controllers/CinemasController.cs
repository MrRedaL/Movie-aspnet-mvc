using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly CinemaService service;

        public CinemasController(CinemaService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allCinemas = await this.service.GetAllAsync();
            return View(allCinemas);
        }
    }
}

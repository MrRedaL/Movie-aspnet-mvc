using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService service;

        public ActorsController(IActorsService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allActors = await this.service.GetAllActors();
            return View(allActors);
        }

        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")]Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);
            }
            this.service.AddActor(actor);
            return RedirectToAction(nameof(Index));
        }
    }
}

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
            var allActors = await this.service.GetAllAsync();
            return View(allActors);
        }

        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await this.service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/(id)
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await this.service.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }
            return View(actorDetails);
        }

        //Get: Actors/Edit/(id)
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await this.service.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureUrl,Bio")] Actor newActor)
        {
            if (!ModelState.IsValid)
            {
                return View(newActor); 
            }
            await this.service.UpdateByIdAsync(id, newActor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Delete/(id)
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await this.service.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }
            return View(actorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await this.service.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }
            await service.DeleteByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
using AspNetCoreMvcApp.Data;
using AspNetCoreMvcApp.Data.Services;
using AspNetCoreMvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvcApp.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService service;

        public CinemasController(ICinemasService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allCinemas = await this.service.GetAllAsync();
            return View(allCinemas);
        }

        //Get: Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("LogoUrl,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await this.service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinemas/Details/(id)
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await this.service.GetByIdAsync(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }
            return View(cinemaDetails);
        }

        //Get: Cinemas/Edit/(id)
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await this.service.GetByIdAsync(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }
            return View(cinemaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LogoUrl,Name,Description")] Cinema newCinema)
        {
            if (!ModelState.IsValid)
            {
                return View(newCinema);
            }
            await this.service.UpdateByIdAsync(id, newCinema);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinemas/Delete/(id)
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await this.service.GetByIdAsync(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }
            return View(cinemaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinemaDetails = await this.service.GetByIdAsync(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }
            await service.DeleteByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

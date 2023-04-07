using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService service;

        public ProducersController(IProducersService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allProducers = await this.service.GetAllAsync();
            return View(allProducers);
        }

        //Get: Producers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureUrl,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await this.service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        //Get: Producers/Details/(id)
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await this.service.GetByIdAsync(id);
            if(producerDetails == null)
            {
                return View("NotFound");
            }
            return View(producerDetails);
        }

        //Get: Producers/Edit/(id)
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await this.service.GetByIdAsync(id);
            if (producerDetails == null)
            {
                return View("NotFound");
            }
            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureUrl,Bio")] Producer newProducer)
        {
            if (!ModelState.IsValid)
            {
                return View(newProducer);
            }
            await this.service.UpdateByIdAsync(id, newProducer);
            return RedirectToAction(nameof(Index));
        }

        //Get: Producers/Delete/(id)
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await this.service.GetByIdAsync(id);
            if (producerDetails == null)
            {
                return View("NotFound");
            }
            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await this.service.GetByIdAsync(id);
            if (producerDetails == null)
            {
                return View("NotFound");
            }
            await service.DeleteByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

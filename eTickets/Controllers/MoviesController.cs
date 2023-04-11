using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService service;

        public MoviesController(IMoviesService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allMovies = await this.service.GetAllAsync(n => n.Cinema);
            return View(allMovies);
        }

        //Get: Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await this.service.GetNewMovieDropdownsValuesAsync();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM newMovie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await this.service.GetNewMovieDropdownsValuesAsync();
                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
                return View(newMovie);
            }
            await this.service.AddNewMovieAsync(newMovie);
            return RedirectToAction(nameof(Index));
        }


        //Get: Movies/Details/(id)
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await this.service.GetMovieByIdAsync(id);
            return View(movieDetail);
        }
    }
}

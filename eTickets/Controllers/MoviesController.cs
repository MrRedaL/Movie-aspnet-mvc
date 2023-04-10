using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Create()
        {
            ViewData["Welcome"] = "Welcome to our store";
            ViewBag.Description = "This is the store description";
            return View();
        }


        //Get: Movies/Details/(id)
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await this.service.GetMovieByIdAsync(id);
            return View(movieDetail);
        }
    }
}

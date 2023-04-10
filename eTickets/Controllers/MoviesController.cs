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
            var allMovies = await this.service.GetAllAsync();
            return View(allMovies);
        }
    }
}

using eTickets.Data;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContext context;

        public ActorsController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var data = this.context.Actors.ToList();
            return View();
        }
    }
}

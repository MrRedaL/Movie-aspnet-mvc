using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace eTickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext context;

        public MoviesService(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValuesAsync()
        {
            var response = new NewMovieDropdownsVM()
            {
                Actors = await this.context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await this.context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await this.context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }
    }
}

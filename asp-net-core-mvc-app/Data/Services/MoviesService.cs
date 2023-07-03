using AspNetCoreMvcApp.Data.Base;
using AspNetCoreMvcApp.Data.ViewModels;
using AspNetCoreMvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.IdentityModel.Tokens;

namespace AspNetCoreMvcApp.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext context;

        public MoviesService(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var newMovie = new Movie()
            {
                ImageUrl = data.ImageUrl,
                Title = data.Title,
                Description = data.Description,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                Price = data.Price,
                Category = data.MovieCategory,
                CinemaId = data.CinemaId,
                ProducerId = data.ProducerId
            };
            await this.context.Movies.AddAsync(newMovie);
            await this.context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await this.context.Actors_Movies.AddAsync(newActorMovie);
            }
            await this.context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieAsync(int id)
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

        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var dbMovie = await this.context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbMovie != null)
            {
                dbMovie.Title = data.Title;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageUrl = data.ImageUrl;
                dbMovie.CinemaId = data.CinemaId;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.Category = data.MovieCategory;
                dbMovie.ProducerId = data.ProducerId;
                await this.context.SaveChangesAsync();
            }

            //Remove existing actors
            var existingActorsDb = this.context.Actors_Movies.Where(n => n.MovieId == data.Id).ToList();
            this.context.Actors_Movies.RemoveRange(existingActorsDb);
            await this.context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = data.Id,
                    ActorId = actorId
                };
                await this.context.Actors_Movies.AddAsync(newActorMovie);
            }
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(NewMovieVM data)
        {
            var dbMovie = await this.context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbMovie != null)
            {
                EntityEntry entityEntry = this.context.Entry(dbMovie);
                entityEntry.State = EntityState.Deleted;
                await this.context.SaveChangesAsync();
            }
        }
    }
}

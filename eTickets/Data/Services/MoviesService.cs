﻿using eTickets.Data.Base;
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
                Category = data.Category,
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

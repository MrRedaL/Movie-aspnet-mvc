using AspNetCoreMvcApp.Data.Base;
using AspNetCoreMvcApp.Data.ViewModels;
using AspNetCoreMvcApp.Models;

namespace AspNetCoreMvcApp.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValuesAsync();
        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);
        Task DeleteMovieAsync(NewMovieVM data);
    }
}

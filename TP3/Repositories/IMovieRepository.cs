using TP3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TP3.Repositories
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        /// Get all movies with their genre included
        Task<List<Movie>> GetAllMoviesWithGenreAsync();

        /// Get movies by genre
        Task<List<Movie>> GetMoviesByGenreAsync(int genreId);

        /// Get movies with stock greater than zero
        Task<List<Movie>> GetMoviesWithStockAsync();

        /// Search movies by title or description
        Task<List<Movie>> SearchMoviesAsync(string searchTerm);

        /// Get movies sorted by release date
        Task<List<Movie>> GetMoviesSortedByReleaseDateAsync();
    }
}
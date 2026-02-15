using Microsoft.EntityFrameworkCore;
using TP3.Data;
using TP3.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP3.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllMoviesWithGenreAsync()
        {
            return await _context.Movies
                .Include(m => m.Genre)
                .ToListAsync();
        }

        public async Task<List<Movie>> GetMoviesByGenreAsync(int genreId)
        {
            return await _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.GenreId == genreId)
                .ToListAsync();
        }

        public async Task<List<Movie>> GetMoviesWithStockAsync()
        {
            return await _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.Stock > 0)
                .ToListAsync();
        }

        public async Task<List<Movie>> SearchMoviesAsync(string searchTerm)
        {
            return await _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.Title.Contains(searchTerm) || m.Description.Contains(searchTerm))
                .ToListAsync();
        }

        public async Task<List<Movie>> GetMoviesSortedByReleaseDateAsync()
        {
            return await _context.Movies
                .Include(m => m.Genre)
                .OrderBy(m => m.ReleaseDate)
                .ThenBy(m => m.Title)
                .ToListAsync();
        }
    }
}
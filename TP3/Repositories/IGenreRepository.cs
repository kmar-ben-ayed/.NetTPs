using TP3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TP3.Repositories
{
  
    public interface IGenreRepository : IGenericRepository<Genre>
    {
       
        Task<List<Genre>> GetAllGenresWithMoviesAsync();

      
        Task<Genre> GetGenreWithMostMoviesAsync();

        
        Task<List<Genre>> GetTopGenresWithMostMoviesAsync(int count);
    }
}
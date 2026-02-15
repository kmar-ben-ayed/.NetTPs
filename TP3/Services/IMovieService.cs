using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TP3.Services
{
    public interface IMovieService
    {
       
        Task<List<MovieServiceDTO>> GetActionMoviesWithStockAsync();
        
        Task<List<MovieServiceDTO>> GetMoviesSortedByReleaseDateAndTitleAsync();

        
        Task<int> GetTotalMovieCountAsync();

        /// Get all customers subscribed to newsletter with discount rate > 10%
        Task<List<CustomerServiceDTO>> GetSubscribedCustomersWithHighDiscountAsync();

        /// Get movies with their genres in format "Title - Genre"
        Task<List<MovieGenreDTO>> GetMoviesWithGenresAsync();

        /// Get top 3 genres with most movies count
        Task<List<GenreCountDTO>> GetTop3GenresWithMostMoviesAsync();
    }

    public class MovieServiceDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        public decimal Rating { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public string ImageFile { get; set; }
        public int Stock { get; set; }
    }

    public class CustomerServiceDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int MembershipTypeId { get; set; }
        public string MembershipTypeName { get; set; }
        public decimal DiscountRate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
    }

    public class MovieGenreDTO
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string GenreName { get; set; }
        public string Display { get; set; } // Format: "Title - Genre"
    }

    public class GenreCountDTO
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public int MovieCount { get; set; }
    }
}
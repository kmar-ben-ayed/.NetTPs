using Microsoft.AspNetCore.Mvc;
using TP3.Repositories;
using System.Threading.Tasks;

namespace TP3.Controllers
{
    public class RepositoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWorkRepository;

        public RepositoryController(IUnitOfWork unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
        }

        // GET: Repository
        public async Task<IActionResult> Index()
        {
            ViewBag.TotalMovies = await _unitOfWorkRepository.Movies.CountAsync();
            ViewBag.TotalCustomers = await _unitOfWorkRepository.Customers.CountAsync();
            ViewBag.TotalGenres = await _unitOfWorkRepository.Genres.CountAsync();
            ViewBag.TotalMembershipTypes = await _unitOfWorkRepository.MembershipTypes.CountAsync();

            return View();
        }

        // GET: Repository/Movies
        public async Task<IActionResult> Movies()
        {
            var movies = await _unitOfWorkRepository.Movies.GetAllMoviesWithGenreAsync();
            return View(movies);
        }

        // GET: Repository/Customers
        public async Task<IActionResult> Customers()
        {
            var customers = await _unitOfWorkRepository.Customers.GetAllCustomersWithMembershipAsync();
            return View(customers);
        }

        // GET: Repository/Genres
        public async Task<IActionResult> Genres()
        {
            var genres = await _unitOfWorkRepository.Genres.GetAllGenresWithMoviesAsync();
            return View(genres);
        }

        // GET: Repository/TopGenres
        public async Task<IActionResult> TopGenres()
        {
            var topGenres = await _unitOfWorkRepository.Genres.GetTopGenresWithMostMoviesAsync(3);
            return View(topGenres);
        }

        // GET: Repository/MoviesWithStock
        public async Task<IActionResult> MoviesWithStock()
        {
            var movies = await _unitOfWorkRepository.Movies.GetMoviesWithStockAsync();
            return View(movies);
        }

        // GET: Repository/NewsletterSubscribers
        public async Task<IActionResult> NewsletterSubscribers()
        {
            var customers = await _unitOfWorkRepository.Customers.GetNewsletterSubscribersAsync();
            return View(customers);
        }

        // GET: Repository/HighDiscountCustomers
        public async Task<IActionResult> HighDiscountCustomers()
        {
            var customers = await _unitOfWorkRepository.Customers.GetCustomersWithHighDiscountAsync();
            return View(customers);
        }

        // GET: Repository/SearchMovies?searchTerm=action
        public async Task<IActionResult> SearchMovies(string searchTerm)
        {
            ViewBag.SearchTerm = searchTerm;
            if (string.IsNullOrEmpty(searchTerm))
            {
                return View(new System.Collections.Generic.List<Models.Movie>());
            }

            var movies = await _unitOfWorkRepository.Movies.SearchMoviesAsync(searchTerm);
            return View(movies);
        }

        // GET: Repository/SearchCustomers?searchTerm=john
        public async Task<IActionResult> SearchCustomers(string searchTerm)
        {
            ViewBag.SearchTerm = searchTerm;
            if (string.IsNullOrEmpty(searchTerm))
            {
                return View(new System.Collections.Generic.List<Models.Customer>());
            }

            var customers = await _unitOfWorkRepository.Customers.SearchCustomersAsync(searchTerm);
            return View(customers);
        }
    }
}
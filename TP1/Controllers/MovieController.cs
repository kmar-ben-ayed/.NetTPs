using Microsoft.AspNetCore.Mvc;
using TP1.Models;
using TP1.ViewModels;
using System.Collections.Generic;

namespace TP1.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            var movies = new List<Movie>
            {
                new Movie { Id = 1, Name = "Five Feet Apart" },
                new Movie { Id = 2, Name = "Interstellar" },
                new Movie { Id = 3, Name = "Repunzel" }
            };

            return View(movies);
        }

        public IActionResult Edit(int id)
        {
            return Content("Test Id: " + id);
        }

        [Route("Movie/released/{year:int}/{month:int}")]
        public IActionResult ByRelease(int year, int month)
        {
            return Content($"Movies released in {month}/{year}");
        }

        public IActionResult CustomerMovies(int id)
        {
            var customer = new Customer { Id = id, Name = "Omar" };

            var movies = new List<Movie>
            {
                new Movie { Id = 1, Name = "Matrix" },
                new Movie { Id = 2, Name = "Avatar" },
                new Movie { Id = 3, Name = "Gladiator" }
            };

            var vm = new MovieCustomerViewModel
            {
                Customer = customer,
                Movies = movies
            };

            return View(vm);
        }

        public IActionResult MovieDetails(int id)
        {
            var movies = new List<Movie>
            {
                new Movie { Id = 1, Name = "Five Feet Apart" },
                new Movie { Id = 2, Name = "Interstellar" },
                new Movie { Id = 3, Name = "Repunzel" }
            };

            var movie = movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return View(movie);
        }
    }
}
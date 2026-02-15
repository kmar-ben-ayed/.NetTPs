using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using TP3.Models;
namespace TP3.ViewModels
{
    public class MovieVM
    {
        public Movie Movie { get; set; } = new Movie();
        
        [Display(Name = "Photo")]
        public IFormFile? Photo { get; set; }
    }
}
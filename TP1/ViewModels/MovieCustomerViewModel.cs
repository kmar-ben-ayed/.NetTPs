using TP1.Models;
using System.Collections.Generic;

namespace TP1.ViewModels
{
    public class MovieCustomerViewModel
    {
        public Customer? Customer { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}
using System.Collections.Generic;
using System.Linq;
using TP3.Models;
namespace TP3.ViewModels
{
    public class CustomerListViewModel
    {
        public List<Customer> Customers { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string SearchString { get; set; }
    }
}
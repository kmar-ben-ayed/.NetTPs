using TP3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TP3.Repositories
{
    
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
       
        Task<List<Customer>> GetAllCustomersWithMembershipAsync();

        
        Task<List<Customer>> GetCustomersByMembershipAsync(int membershipTypeId);

        
        Task<List<Customer>> GetNewsletterSubscribersAsync();

        
        Task<List<Customer>> GetCustomersWithHighDiscountAsync();

       
        Task<List<Customer>> SearchCustomersAsync(string searchTerm);
    }
}
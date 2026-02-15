using TP3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TP3.Repositories
{
    /// MembershipType Repository Interface - extends generic repository with membership-specific operations
    public interface IMembershipTypeRepository : IGenericRepository<MembershipType>
    {
        /// Get all membership types with their customers included
        Task<List<MembershipType>> GetAllMembershipTypesWithCustomersAsync();

        /// Get membership types with discount > specific percentage
        Task<List<MembershipType>> GetMembershipTypesWithDiscountAsync(decimal discountPercentage);
    }
}
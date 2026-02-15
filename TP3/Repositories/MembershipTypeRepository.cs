using Microsoft.EntityFrameworkCore;
using TP3.Data;
using TP3.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP3.Repositories
{
    
    public class MembershipTypeRepository : GenericRepository<MembershipType>, IMembershipTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public MembershipTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<MembershipType>> GetAllMembershipTypesWithCustomersAsync()
        {
            return await _context.MembershipTypes
                .Include(m => m.Customers)
                .ToListAsync();
        }

        public async Task<List<MembershipType>> GetMembershipTypesWithDiscountAsync(decimal discountPercentage)
        {
            return await _context.MembershipTypes
                .Include(m => m.Customers)
                .Where(m => m.DiscountRate > discountPercentage)
                .ToListAsync();
        }
    }
}
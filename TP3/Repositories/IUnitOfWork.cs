using System;
using System.Threading.Tasks;

namespace TP3.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieRepository Movies { get; }
        ICustomerRepository Customers { get; }
        IGenreRepository Genres { get; }
        IMembershipTypeRepository MembershipTypes { get; }

        Task<bool> SaveAsync();

        Task BeginTransactionAsync();

        
        Task CommitAsync();

        
        Task RollbackAsync();
    }
}
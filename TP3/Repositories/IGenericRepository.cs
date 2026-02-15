using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TP3.Repositories
{
   
    public interface IGenericRepository<T> where T : class
    {
        // CRUD Operations
       
        Task<T> GetByIdAsync(int id);

       
        Task<List<T>> GetAllAsync();

       
        Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);

       
        Task<T> AddAsync(T entity);

        
        Task<T> UpdateAsync(T entity);

      
        Task<bool> DeleteAsync(int id);

      
        Task<bool> DeleteAsync(T entity);

       
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);

      
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        
        Task<T> FindSingleAsync(Expression<Func<T, bool>> predicate);

        
        Task<T> FindSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

      
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

      
        Task<int> CountAsync();

        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

        Task<PaginatedResult<T>> GetPaginatedAsync(int pageNumber, int pageSize);

        
        Task<PaginatedResult<T>> GetPaginatedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> predicate);

      
        Task<PaginatedResult<T>> GetPaginatedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> predicate, 
            params Expression<Func<T, object>>[] includes);

        Task<List<T>> AddRangeAsync(List<T> entities);

       
        Task<bool> DeleteRangeAsync(List<T> entities);

       
        Task<bool> SaveAsync();
    }

    
    public class PaginatedResult<T> where T : class
    {
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (TotalCount + PageSize - 1) / PageSize;
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }
}
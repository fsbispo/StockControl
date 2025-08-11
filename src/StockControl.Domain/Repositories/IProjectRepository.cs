using StockControl.Domain.Entities;

namespace StockControl.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task<Product?> GetByIdAsync(Guid id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Product>> GetProductsBelowMinimumStockAsync();
    }
}

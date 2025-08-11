using StockControl.Domain.Entities;

namespace StockControl.Domain.Repositories
{
    public interface IStockMovementRespository
    {
        Task<IEnumerable<StockMovement>> GetByProductIdAsync(Guid productId);
        Task AddAsync(StockMovement stockMovement);
    }
}

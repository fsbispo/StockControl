using StockControl.Domain.Repositories;

namespace StockControl.Application.Handlers.Products
{
    public class RemoveStockHandler
    {
        public readonly IProductRepository _productRepository;

        public RemoveStockHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(Guid productId, int quantity)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            product.RemoveStock(quantity);
            await _productRepository.UpdateAsync(product);
        }
    }
}

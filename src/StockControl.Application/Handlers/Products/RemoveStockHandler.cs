using StockControl.Application.Commands.Products;
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

        public async Task Handle(RemoveStockCommand command)
        {
            var product = await _productRepository.GetByIdAsync(command.ProductId);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            product.RemoveStock(command.Quantity);
            await _productRepository.UpdateAsync(product);
        }
    }
}

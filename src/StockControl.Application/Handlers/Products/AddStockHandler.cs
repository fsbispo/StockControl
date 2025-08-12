using StockControl.Application.Commands.Products;
using StockControl.Domain.Repositories;

namespace StockControl.Application.Handlers.Products
{
    public class AddStockHandler
    {
        public readonly IProductRepository _productRepository;

       public AddStockHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(AddStockCommand command)
        {
            var product = await _productRepository.GetByIdAsync(command.ProductId);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            product.AddStock(command.Quantity);
            await _productRepository.UpdateAsync(product);
        }
    }
}

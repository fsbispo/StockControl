using StockControl.Application.Commands.Products;
using StockControl.Domain.Entities;
using StockControl.Domain.Repositories;

namespace StockControl.Application.Handlers.Products
{
    public class CreateProductHandler
    {
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(CreateProductCommand command)
        {
            var product = new Product(command.Name, command.MinimumStock);
            await _productRepository.AddAsync(product);
        }
    }
}

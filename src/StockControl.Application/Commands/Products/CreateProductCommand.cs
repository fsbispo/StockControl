namespace StockControl.Application.Commands.Products
{
    public class CreateProductCommand
    {
        public string Name { get; set; }
        public int MinimumStock { get; set; }
    }
}

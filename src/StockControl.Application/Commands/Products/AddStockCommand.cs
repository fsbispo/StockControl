namespace StockControl.Application.Commands.Products
{
    public class AddStockCommand
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

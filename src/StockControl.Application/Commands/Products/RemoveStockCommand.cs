namespace StockControl.Application.Commands.Products
{
    public class RemoveStockCommand
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

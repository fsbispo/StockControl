using StockControl.Domain.Enumerators;

namespace StockControl.Domain.Entities
{
    public class StockMovement
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public MovementType Type { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

        public StockMovement(Guid productId, MovementType type, int quantity)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            Type = type;
            Quantity = quantity;
            Date = DateTime.UtcNow;
        }
    }
}

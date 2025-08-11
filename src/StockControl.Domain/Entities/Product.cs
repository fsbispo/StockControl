namespace StockControl.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int MinimumStock { get; set; }

        public Product(string name, int minimumStock)
        {
            Id = Guid.NewGuid();
            Name = name;
            MinimumStock = minimumStock;
            Quantity = 0;
        }

        public void AddStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
            
            Quantity += quantity;
        }

        public void RemoveStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
            if (quantity > Quantity)
                throw new InvalidOperationException("Insufficient stock to remove the specified quantity.");
            Quantity -= quantity;
        }

        public bool IsBelowMinimumStock()
        {
            return Quantity < MinimumStock;
        }
    }
}
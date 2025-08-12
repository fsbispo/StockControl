using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Domain.Commands.Products
{
    public class AddStockCommand
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

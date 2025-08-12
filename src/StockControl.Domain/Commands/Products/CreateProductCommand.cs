using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Domain.Commands.Products
{
    public class CreateProductCommand
    {
        public string Name { get; set; }
        public int MinimumStock { get; set; }
    }
}

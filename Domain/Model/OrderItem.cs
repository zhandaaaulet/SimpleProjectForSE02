using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class OrderItem
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderedDate { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}

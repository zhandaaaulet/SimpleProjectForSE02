using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal CurrentPrice { get; set; }
    }
}

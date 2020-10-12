using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Model
{
    public class Basket
    {
        private readonly List<BasketItem> _items;

        public Basket(int customerId)
        {
            _items = new List<BasketItem>();
            CustomerId = customerId;
        }
        
        public int CustomerId { get; }
        public List<BasketItem> BasketItems { get; set; }

        public IReadOnlyList<BasketItem> Items => _items;

        public void AddItem(int itemId)
        {
            AddItem(itemId, 1);
        
        }
        public void AddItem(int itemId, int quantity)
        {
            var item = _items.FirstOrDefault(i => i.ItemId == itemId);

            if(item is { }) //if it is not null
            {
                item.Quantity += quantity;
            }
            else
            {
                _items.Add(new BasketItem(CustomerId, itemId, quantity));
            }
            
        }

        public void RemoveItem(int itemId)
        {
            RemoveItem(itemId, 1);
        }

        public void RemoveItem(int itemId, int quantity)
        {
            var item = _items.FirstOrDefault(i => i.ItemId == itemId);

            if(item is { })
            {
                item.Quantity -= quantity;
                if(item.HasAny)
                {
                    _items.Remove(item);
                }
            }
           // _items.RemoveAll(item => item.ItemId == itemId);
        }
    }
}

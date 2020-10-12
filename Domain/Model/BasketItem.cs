using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class BasketItem
    {
        private int _quantity;
        public BasketItem(int basketId, int itemId, int quantity)
        {
            BasketId = basketId;
            ItemId = itemId;
            Quantity = quantity;
        }
        public int BasketId { get;}
        public int ItemId { get;}

        public int Quantity {
            get
            {
                return _quantity;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _quantity = value;
            }
        }

        public bool HasAny => Quantity != 0;
    }
}

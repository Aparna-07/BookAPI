using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookAPI.Models
{
    public class OrderItems
    {
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Qty { get; set; }

        public OrderItems(int orderId, int bookId, int qty)
        {
            OrderId = orderId;
            BookId = bookId;
            Qty = qty;
        }
    }
}
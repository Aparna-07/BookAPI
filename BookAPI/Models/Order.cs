using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }

        public Order(int orderId, DateTime orderDate, decimal amount, int userId)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            Amount = amount;
            UserId = userId;
        }

        public Order() { }
    }

    public class OrderItem
    {
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Qty { get; set; }

        public OrderItem(int orderId, int bookId, int qty)
        {
            OrderId = orderId;
            BookId = bookId;
            Qty = qty;
        }
    }
}
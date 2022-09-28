using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookAPI.Models
{
    public class Order
    {
        public DateTime OrderDate { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Qty { get; set; }

        public Order(DateTime orderDate, string userName, string title, string author, int qty)
        {
            OrderDate = orderDate;
            UserName = userName;
            Title = title;
            Author = author;
            Qty = qty;
        }
    }

    public class Orders
    {
        public DateTime OrderDate { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }

        public Orders(DateTime orderDate, decimal amount, int userId)
        {
            OrderDate = orderDate;
            Amount = amount;
            UserId = userId;
        }
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
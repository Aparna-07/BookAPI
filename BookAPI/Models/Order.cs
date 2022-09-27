﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookAPI.Models
{
    //(OrderDate, Amount, AddressId, UserId)
    //OrderItems(OrderId, BookId, Qty)
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Amount { get; set; }
        public int AddressId { get; set; }
        public int UserId { get; set; }


        public Order(int orderId, DateTime orderDate, decimal amount, int addressId, int userId)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            Amount = amount;
            AddressId = addressId;
            UserId = userId;
        }

    }

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookAPI.Models
{
    public class Cart
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Qty { get; set; }

        public Cart(int userId, int bookId, int qty)
        {
            UserId = userId;
            BookId = bookId;
            Qty = qty;
        }
    }

    public class Wishlist
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public Wishlist(int userId, int bookId)
        {
            UserId = userId;
            BookId = bookId;
        }
    }
}
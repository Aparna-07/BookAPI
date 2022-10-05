using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookAPI.Models
{
    public class CartService : ICart
    {
        SqlConnection conn;
        SqlCommand comm;
        public CartService()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BooksDB"].ConnectionString);
            comm = new SqlCommand();
            comm.Connection = conn;
        }

        public List<Cart> GetCart(int userId)
        {
            List<Cart> cartItems = new List<Cart>();
            comm.CommandText = "select * from Cart where UserId = " + userId;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                cartItems.Add(new Cart(
                    reader.GetInt32(1),
                    reader.GetInt32(2),
                    reader.GetInt32(3)));
            }
            conn.Close();
            return cartItems;
        }


        public Cart InsertCart(Cart cart)
        {
            comm.CommandText= "select * from Cart where UserId = " + cart.UserId + " and BookId = " + cart.BookId;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                int qty;
                while (reader.Read())
                {
                    qty = reader.GetInt32(3);
                    cart.Qty += qty;
                    conn.Close();
                    return UpdateCart(cart);
                }
            }
            conn.Close();
            conn.Open();
            comm.CommandText = "insert into Cart(UserId, BookId, Qty) values(" + cart.UserId + ", " + cart.BookId + ", " + cart.Qty + ") ";
            comm.ExecuteNonQuery();
            conn.Close();
            return cart;
        }


        public Cart UpdateCart(Cart cart)
        {
            comm.CommandText = "update Cart set Qty = " + cart.Qty + " where UserId = "+cart.UserId+" and BookId = " + cart.BookId;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            return cart;
        }

        public void DeleteCart(Cart cart)
        {
            comm.CommandText = "delete from Cart where UserId = " + cart.UserId + " and BookId = " + cart.BookId;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteFullCart(int userId)
        {
            comm.CommandText = "delete from Cart where UserId = " + userId;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public decimal GetTotal(int userId)
        {
            decimal total = 0;
            comm.CommandText = "select SUM(Qty*Price) from Cart C, Book B where C.BookId = B.BookId and UserId = " + userId;
            conn.Open();
            object result = comm.ExecuteScalar();
            if (typeof(decimal).IsAssignableFrom(result.GetType()))
                total = Convert.ToDecimal(result);
            conn.Close();
            return total;
        }
    }
}
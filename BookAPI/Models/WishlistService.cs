using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookAPI.Models
{
    public class WishlistService : IWishlist
    {
        SqlConnection conn;
        SqlCommand comm;
        public WishlistService()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BooksDB"].ConnectionString);
            comm = new SqlCommand();
            comm.Connection = conn;
        }
        public List<Wishlist> GetWishlist(int userId)
        {
            List<Wishlist> wishItems = new List<Wishlist>();
            comm.CommandText = "select * from Wishlist where Userid = " + userId;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                wishItems.Add(new Wishlist(
                    reader.GetInt32(1),
                    reader.GetInt32(2)));
            }
            conn.Close();
            return wishItems;
        }
        public void DeleteWishlist(Wishlist wishlist)
        {
            comm.CommandText = "delete from Wishlist where UserId = " + wishlist.UserId + " and BookId = " + wishlist.BookId;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public Wishlist InsertWishlist(Wishlist wishlist)
        {
            comm.CommandText = "select * from Wishlist where UserId = " + wishlist.UserId + " and BookId = " + wishlist.BookId;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                conn.Close();
                return wishlist;
            }
            conn.Close();
            conn.Open();
            comm.CommandText = "insert into Wishlist(UserId, BookId) values(" + wishlist.UserId + ", " + wishlist.BookId + ") ";
            comm.ExecuteNonQuery();
            conn.Close();
            return wishlist;
        }
    }
}
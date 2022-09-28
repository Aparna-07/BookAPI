using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BookAPI.Models
{
    public class OrderService : IOrder
    {
        SqlConnection conn;
        SqlCommand comm;

        public OrderService()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BooksDB"].ConnectionString);
            comm = new SqlCommand();
            comm.Connection = conn;
        }

        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();
            comm.CommandText = "select OrderDate, UserName, Title, Author, Qty from Orders O, OrderItems I, Users U, Book B where O.OrderId = I.OrderId and O.UserId = U.UserId and I.BookId = B.BookId";
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                orders.Add(new Order(
                    reader.GetDateTime(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetInt32(4)));
            }
            conn.Close();
            return orders;
        }

        public int InsertOrder(Orders orders)
        {
            comm.CommandText = "insert into Orders(OrderDate, Amount, UserId) values('"+orders.OrderDate+"', "+orders.Amount+", "+orders.UserId+")";
            conn.Open();
            comm.ExecuteNonQuery();
            comm.CommandText = "select OrderId from Orders where UserId = "+orders.UserId+" order by OrderDate desc";
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int orderId = reader.GetInt32(0);
                conn.Close();
                return orderId;
            }
            return 0;
        }

        public OrderItem InsertItem(OrderItem item)
        {
            comm.CommandText = "insert into OrderItems(OrderId, BookId, Qty) values(" + item.OrderId + ", " + item.BookId + ", " + item.Qty + ")";
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            return item;
        }
    }
}
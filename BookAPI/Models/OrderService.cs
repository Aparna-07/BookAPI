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
            comm.CommandText = "select * from Orders";
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                orders.Add(new Order(
                    reader.GetInt32(0),
                    reader.GetDateTime(1),
                    reader.GetDecimal(2),
                    reader.GetInt32(3)));
            }
            conn.Close();
            return orders;
        }

        public List<Order> GetOrderByUser(int userId)
        {
            List<Order> orders = new List<Order>();
            comm.CommandText = "select * from Orders where UserId = " + userId;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                orders.Add(new Order(
                    reader.GetInt32(0),
                    reader.GetDateTime(1),
                    reader.GetDecimal(2),
                    reader.GetInt32(3)));
            }
            conn.Close();
            return orders;
        }

        public List<OrderItem> GetOrderItems(int orderId)
        {
            List<OrderItem> orders = new List<OrderItem>();
            comm.CommandText = "select * from OrderItems where OrderId = " + orderId;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                orders.Add(new OrderItem(
                    reader.GetInt32(1),
                    reader.GetInt32(2),
                    reader.GetInt32(3)));
            }
            conn.Close();
            return orders;
        }

        public int InsertOrder(Order order)
        {
            comm.CommandText = "insert into Orders(OrderDate, Amount, UserId) values('"+order.OrderDate+"', "+order.Amount+", "+order.UserId+")";
            conn.Open();
            comm.ExecuteNonQuery();
            comm.CommandText = "select OrderId from Orders where UserId = "+order.UserId+" order by OrderDate desc";
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BookAPI.Models
{
    public class OrderService
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
                    reader.GetInt32(3),
                    reader.GetInt32(4)));
            }
            conn.Close();
            return orders;
        }
        public List<OrderItems> GetOrderItems(int orderId)
        {
            List<OrderItems> items = new List<OrderItems>();
            comm.CommandText = "select * from OrderItems where OrderId = " + orderId;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                items.Add(new OrderItems(
                    reader.GetInt32(1),
                    reader.GetInt32(2),
                    reader.GetInt32(3)));
            }
            conn.Close();
            return items;
        }
    }
}
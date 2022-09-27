using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    internal interface IOrder
    {
        List<Order> GetAllOrders();
        List<OrderItems> GetOrderItems(int orderId);
        List<Order> GetOrdersByUser(int userId);
    }
}

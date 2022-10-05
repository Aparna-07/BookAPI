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
        List<Order> GetOrderByUser(int userId);
        List<OrderItem> GetOrderItems(int orderId);
        int InsertOrder(Order order);
        OrderItem InsertItem(OrderItem item);
    }
}

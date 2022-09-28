using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public interface ICart
    {
        List<Cart> GetCart(int userId);
        Cart InsertCart(Cart cart);
        Cart UpdateCart(Cart cart);
        void DeleteCart(Cart cart);
        void DeleteFullCart(int userId);
        decimal GetTotal(int userId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public interface IWishlist
    {
        List<Wishlist> GetWishlist(int userId);
        Wishlist InsertWishlist(Wishlist wishlist);
        void DeleteWishlist(Wishlist wishlist);
    }
}

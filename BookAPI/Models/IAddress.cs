using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public interface IAddress
    {
        Address GetAddress(int userId);

        Address UpdateAddress(Address address);
        Address InsertAddress(Address address);
        void DeleteAddress(int userId);
    }
}

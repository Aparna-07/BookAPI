using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public interface IAuth
    {
        User Login(Credentials credentials);
        User Register(User user);
    }
}

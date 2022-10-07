using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public interface IAuth
    {
        List<User> GetUsers();
        User Login(Credentials credentials);
        User Register(User user);

        void ActivateUser(int userId);
        void DeactivateUser(int userId);
    }
}

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

        List<User> GetUsers();
        void ActivateUser(int userId);
        void DeactivateUser(int userId);
        User UpdateUsername(string name, int userId);
        User UpdateEmail(string email, int userId);
        User UpdatePassword(string password, int userId);
        bool CheckDuplicateEmail(string email);
    }
}

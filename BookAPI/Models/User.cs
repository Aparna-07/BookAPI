using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Mobile { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public bool IsAdmin { get; set; }


        public User()
        {

        }
        public User(int userId, string name, string email, int mobile, string pass, bool isActive, bool isAdmin)
        {
            UserId = userId;
            UserName = name;
            Email = email;
            Mobile = mobile;
            Password = pass;
            IsActive = isActive;
            IsAdmin = isAdmin;
        }
    }

    public class Credentials
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public Credentials(string email, string pass)
        {
            Email = email;
            Password = pass;
        }
    }
}
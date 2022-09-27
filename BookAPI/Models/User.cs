using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookAPI.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Mobile { get; set; }
        public string Password { get; set; }

        public User()
        {

        }
        public User(string name, string email, int mobile, string pass)
        {
            UserName = name;
            Email = email;
            Mobile = mobile;
            Password = pass;
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
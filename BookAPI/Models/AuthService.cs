using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookAPI.Models
{
    public class AuthService :IAuth
    {
        SqlConnection conn;
        SqlCommand comm;
        public AuthService()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BooksDB"].ConnectionString);
            comm = new SqlCommand();
            comm.Connection = conn;
        }
        public User Login(Credentials credentials)
        {
            comm.CommandText = "select * from Users where Email = '"+credentials.Email+ "' and Password = '" + credentials.Password + "'";
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            conn.Close();
            if(reader.HasRows)
            {
                while (reader.Read())
                {
                    User user = new User(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3));
                    conn.Close();
                    return user;
                }
            }
            return null;
        }

        public User Register(User user)
        {
            comm.CommandText = "insert into Users(UserName, Email, Mobile, Password, IsActive, IsAdmin)" +
                "values('"+user.UserName+ "', '" + user.Email + "', " + user.Mobile + ", '" + user.Password + "', 1, 0)";
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            return user;
        }
    }
}
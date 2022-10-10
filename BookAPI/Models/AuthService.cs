using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookAPI.Models
{
    public class AuthService : IAuth
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
            comm.CommandText = "select * from Users where Email = '" + credentials.Email + "' and Password = '" + credentials.Password + "'";
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                User user = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetBoolean(5), reader.GetBoolean(6));
                conn.Close();
                return user;
            }
            conn.Close();
            return null;
        }

        public User Register(User user)
        {
            comm.CommandText = "insert into Users(UserName, Email, Mobile, Password, IsActive, IsAdmin)" +
                "values('" + user.UserName + "', '" + user.Email + "', " + user.Mobile + ", '" + user.Password + "', 1, 0)";
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            return user;
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            comm.CommandText = "select * from Users where IsAdmin=0";
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    users.Add(new User(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetInt32(3),
                        reader.GetString(4),
                        reader.GetBoolean(5),
                        reader.GetBoolean(6)));
                }
            }
            conn.Close();
            return users;
        }

        public void ActivateUser(int userId)
        {
            comm.CommandText = "update Users set IsActive = 1 where UserId = " + userId;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public void DeactivateUser(int userId)
        {
            comm.CommandText = "update Users set IsActive = 0 where UserId = " + userId;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public User UpdateUsername(string name, int userId)
        {
            {
                comm.CommandText = "update Users set Username = '" + name + "' where UserId = " + userId;
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
                comm.CommandText = "select * from Users where UserId = " + userId;
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetBoolean(5), reader.GetBoolean(6));
                    conn.Close();
                    return user;
                }
                conn.Close();
                return null;
            }
        }

        public User UpdateEmail(string email, int userId)
        {
            comm.CommandText = "update Users set Email = '" + email + "' where UserId = " + userId;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            comm.CommandText = "select * from Users where UserId = " + userId;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                User user = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetBoolean(5), reader.GetBoolean(6));
                conn.Close();
                return user;
            }
            conn.Close();
            return null;
        }

        public User UpdatePassword(string password, int userId)
        {
            comm.CommandText = "update Users set Password = '" + password + "' where UserId = " + userId;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            comm.CommandText = "select * from Users where UserId = " + userId;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                User user = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetBoolean(5), reader.GetBoolean(6));
                conn.Close();
                return user;
            }
            conn.Close();
            return null;
        }

        public bool CheckDuplicateEmail(string email)
        {
            comm.CommandText = "select * from Users where Email = '"+email+"'";
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows) 
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookAPI.Models
{
    public class AddressService : IAddress
    {
        SqlConnection conn;
        SqlCommand comm;
        public AddressService()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BooksDB"].ConnectionString);
            comm = new SqlCommand();
            comm.Connection = conn;
        }

        public Address InsertAddress(Address address)
        {
            DeleteAddress(address.UserId);
            comm.CommandText = "insert into Address(Building, City, Country, Pincode, UserId) " +
                "values('" + address.Building + "', '" + address.City + "', '" + address.Country + "', " + address.Pincode + ", " + address.UserId + ") ";
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            return address;
        }

        public Address UpdateAddress(Address address)
        {
            comm.CommandText = "update Address set Building = '" + address.Building + "', City = '" + address.City + "', Country = '" + address.Country + "', Pincode = " + address.Pincode + " where UserId = " + address.UserId;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            return address;
        }
        public void DeleteAddress(int userId)
        {
            comm.CommandText = "delete from Address where UserId = " + userId;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public Address GetAddress(int userId)
        {
            Address address;
            comm.CommandText = "select * from Address where UserId = " + userId;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                address = new Address(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetInt32(4),
                    reader.GetInt32(5)
                    );
                conn.Close();
                return address;
            }
            return null;
        }
    }
}
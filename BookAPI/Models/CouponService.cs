using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookAPI.Models
{
    public class CouponService : ICoupon
    {
        SqlConnection conn;
        SqlCommand comm;
        public CouponService()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BooksDB"].ConnectionString);
            comm = new SqlCommand();
            comm.Connection = conn;
        }

        public Coupon GetCoupon(decimal total)
        {
            Coupon coupon;
            comm.CommandText = "select top 1 * from Coupon where MinimumSpend <= " + total + " and Expiry > GETDATE() order by Discount desc ";
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                coupon = new Coupon(
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetInt32(3),
                    reader.GetInt32(4),
                    reader.GetDateTime(5)
                    );
                conn.Close();
                return coupon;
            }
            return null;
        }

        public Coupon InsertCoupon(Coupon coupon)
        {
            comm.CommandText = "insert into Coupon(Code, Description, Discount, MinimumSpend, Expiry) values('"+
                coupon.Code+"', '"+coupon.Description+"', "+coupon.Discount+", "+coupon.MinimumSpend+", '"+coupon.Expiry+"')";
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            return coupon;
        }

        public Coupon UpdateCoupon(Coupon coupon)
        {
            comm.CommandText = "update Coupon set Description = '" + coupon.Description + "', Discount = " + 
                coupon.Discount + ", MinimumSpend = " + coupon.MinimumSpend + ", Expiry = '"+ coupon.Expiry +"' where Code = '" + coupon.Code +"'";
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            return coupon;
        }
        public void DeleteCoupon(string code)
        {
            comm.CommandText = "delete from Coupon where Code = '" + code + "'";
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}
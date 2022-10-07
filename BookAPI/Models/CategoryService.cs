using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Http;

namespace BookAPI.Models
{
    public class CategoryService : ICategory
    {
        SqlConnection conn;
        SqlCommand comm;
        public CategoryService()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BooksDB"].ConnectionString);
            comm = new SqlCommand();
            comm.Connection = conn;
        }
        public Category InsertCategory(Category cat)
        {
            comm.CommandText = "insert into Category(CategoryName, Description, Image, Status, Position, CreatedAt)" +
                " values('" + cat.CategoryName + "', '" + cat.Description + "', '" + cat.Image + "', '" + cat.Status + "', " + cat.Position + " , '" + cat.CreatedAt + "') ";
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            return cat;
        }

        public Category UpdateCategory(Category cat)
        {
            comm.CommandText = "update Category set CategoryName = '" + cat.CategoryName + "'," +
                "Description = '" + cat.Description + "'," +
                "Image = '" + cat.Image + "', " +
                "Status = '" + cat.Status + "', " +
                "Position = " + cat.Position + " , " +
                "CreatedAt = '" + cat.CreatedAt + "' where CategoryId = " + cat.CategoryId;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            return cat;
        }

        public void DeleteCategory(int id)
        {
            comm.CommandText = "delete from Category where CategoryId = " + id;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            comm.CommandText = "select * from Category where Status = 'true' order by Position;";
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                categories.Add(new Category(
                    reader.GetInt32(0), 
                    reader.GetString(1), 
                    reader.GetString(2), 
                    reader.GetString(3), 
                    reader.GetString(4), 
                    reader.GetInt32(5), 
                    reader.GetDateTime(6)));
            }
            conn.Close();
            return categories;
        }

        public Category GetCategoryById(int id)
        {
            Category cat = null; ;
            comm.CommandText = "select * from Category where Status = 'true' and CategoryId = " + id;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                cat = new Category(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetInt32(5),
                    reader.GetDateTime(6));
            }
            conn.Close();
            return cat;
        }

        public List<Category> GetCategoryByName(string name)
        {
            List<Category> categories = new List<Category>(); ;
            comm.CommandText = "select * from Category where Status = 'true' and lower(CategoryName) like lower('%"+name+"%')";
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                categories.Add(new Category(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetInt32(5),
                    reader.GetDateTime(6)));
            }
            conn.Close();
            return categories;
        }
    }
}
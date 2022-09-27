using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BookAPI.Models
{
    public class BookService : IBook
    {
        SqlConnection conn;
        SqlCommand comm;
        public BookService()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BooksDB"].ConnectionString);
            comm = new SqlCommand();
            comm.Connection = conn;
        }
        public List<Book> GetAllBooks()
        {
            string query = "select * from Book where Status = 'true' order by Year desc";
            return GetBooksByVariable(query);
        }

        public List<Book> GetBookByAuthor(string author)
        {
            string query = "select * from Book where Status = 'true' and Author = '"+author+ "' order by Year desc";
            return GetBooksByVariable(query);
        }

        public List<Book> GetBookByCatId(int catId)
        {
            string query = "select * from Book where Status = 'true' and CategoryId = " + catId + " order by Year desc";
            return GetBooksByVariable(query);
        }

        public List<Book> GetBookByCatName(string catName)
        {
            string query = "select * from Book where Status = 'true' and  CategoryId = (select CategoryId from Category where CategoryName = '"+catName+ "') order by Year desc";
            return GetBooksByVariable(query);
        }

        public Book GetBookByISBN(long isbn)
        {
            string query = "select * from Book where Status = 'true' and ISBN = " + isbn + " order by Year desc";
            return GetBookByVariable(query);
        }

        public Book GetBookByName(string name)
        {
            string query = "select * from Book where Status = 'true' and Title = '" + name + "' order by Year desc";
            return GetBookByVariable(query);
        }

        public Book InsertBook(Book book)
        {
            comm.CommandText = "insert into Book(CategoryId, Title, Author, ISBN, Year, Price, Description, Position, Status, Image) " +
                "values("+book.CategoryId+ ", '" + book.Title + "', '" + book.Author + "', " + book.ISBN + ", '" + book.Year + "', " + book.Price + ", '" + book.Description + "', " + book.Position + ", '" + book.Status + "', '" + book.Image + "')";
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            return book;
        }

        public Book UpdateBook(Book book)
        {
            comm.CommandText = "update Book set CategoryId = " + book.CategoryId + ", Title = '" + book.Title + "', Author = '" + book.Author + "'," +
                " ISBN = " + book.ISBN + ", Year = '" + book.Year + "', Price = " + book.Price + ", Description = '" + book.Description + "', Position = " + book.Position + ", " +
                "Status = '" + book.Status + "', Image = '" + book.Image + "' where BookId = " + book.BookId;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            return book;
        }

        public void DeleteBook(int id)
        {
            comm.CommandText = "delete from Book where BookId = " + id;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Book> GetFeaturedBooks()
        {
            string query = "select top 4 * from Book where Status = 'true' order by Position";
            return GetBooksByVariable(query);
        }

        private Book GetBookByVariable(string query)
        {
            Book book = new Book();
            comm.CommandText = query;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                book = new Book(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetInt64(4),
                    reader.GetString(5),
                    reader.GetDecimal(6),
                    reader.GetString(7),
                    reader.GetInt32(8),
                    reader.GetString(9),
                    reader.GetString(10));
            }
            conn.Close();
            return book;
        }

        private List<Book> GetBooksByVariable(string query)
        {
            List<Book> books = new List<Book>();
            comm.CommandText = query;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                books.Add(new Book(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetInt64(4),
                    reader.GetString(5),
                    reader.GetDecimal(6),
                    reader.GetString(7),
                    reader.GetInt32(8),
                    reader.GetString(9),
                    reader.GetString(10)));
            }
            conn.Close();
            return books;
        }
    }
}
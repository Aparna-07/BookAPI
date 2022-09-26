using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookAPI.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public long ISBN { get; set; }
        public string Year { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }

        public Book()
        {

        }
        public Book(int bookId, int catId, string title, string author, long isbn, string year, decimal price, string desc, int pos, string stat, string url)
        {
            BookId = bookId;
            CategoryId = catId; ;
            Title = title;
            Author = author;
            ISBN = isbn;
            Year = year;
            Price = price;
            Description = desc;
            Position = pos;
            Status = stat;
            Image = url;
        }
    }
}
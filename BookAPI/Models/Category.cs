using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookAPI.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public int Position { get; set; }
        public DateTime CreatedAt { get; set; }

        public Category()
        {

        }
        public Category(int id, string name, string desc, string url, string stat, int pos, DateTime date)
        {
            CategoryId = id;
            CategoryName = name;
            Description = desc;
            Image = url;
            Status = stat;
            Position = pos;
            CreatedAt = date;
        }
    }
}
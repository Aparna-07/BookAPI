using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    internal interface IBook
    {
        List<Book> GetAllBooks();
        List<Book> GetBookByCatId(int catId);
        List<Book> GetBookByCatName(string catName);
        List<Book> GetBookByName(string name);
        Book GetBookById(int id);
        Book GetBookByISBN(long isbn);
        List<Book> GetBookByAuthor(string author);
        List<Book> GetFeaturedBooks();

        Book InsertBook(Book book);
        Book UpdateBook(Book book);
        void DeleteBook(int id);
    }
}

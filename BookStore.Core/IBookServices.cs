using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core
{
    public interface IBookServices
    {
        List<Book> GetBooks();
        Book GetBook(string _id);
        List<Book> PostBook(Book book);
        List<Book> DeleteBook(string _id);
        Book UpdateBook(Book book);
    }
    
}

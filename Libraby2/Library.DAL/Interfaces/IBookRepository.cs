using Libraby2.Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraby2.Library.DAL.Interfaces
{
    public interface IBookRepository
    {
        List<BookEntity> GetAllBooks();
        BookEntity SearchBook(int code);
        void AddBook(BookEntity item);
        void DeleteBook(int code);
        void ChangeBook(int id, string name, int count, string author);
    }
}

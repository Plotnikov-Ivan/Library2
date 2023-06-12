using Libraby2.Library.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraby2.Library.BLL.Interfaces
{
    internal interface IBookService
    {
        List<BookDTO> GetAllBooks();
        BookDTO SearchBook(int code);
        void AddBook(BookDTO item);
        void DeleteBook(int code);

        void ChangeBook(int id, string name, int count, string author);
    }
}

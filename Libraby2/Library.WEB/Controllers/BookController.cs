using System;
using Libraby2.Library.BLL.Interfaces;
using Libraby2.Library.BLL.Mappers;
using Libraby2.Library.WEB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraby2.Library.WEB.Controllers
{
    internal class BookController
    {

        private IBookService bookService;
        public BookController(IBookService _bookService)
        {
            bookService = _bookService;
        }
        public void AddBook(BookModel bookModel)
        {
            bookService.AddBook(bookModel.MapBookModelToDto());
        }
        public List<BookModel> GetAllBooks()
        {

            return bookService.GetAllBooks().MapBookListDtoToModel();
        }

        public BookModel SearchBook(int id)
        {
            return bookService.SearchBook(id).MapBookDtoToModel();
        }
        public void DeleteBook(int id)
        {
            bookService.DeleteBook(id);
        }

        public void ChangeBook(int id, string name, int count, string author)
        {
            bookService.ChangeBook(id, name, count ,author);
        }
    }
}

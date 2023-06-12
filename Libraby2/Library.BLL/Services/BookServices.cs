using Libraby2.Library.BLL.DTO;
using Libraby2.Library.BLL.Interfaces;
using Libraby2.Library.BLL.Mappers;
using Libraby2.Library.DAL.Interfaces;
using Libraby2.Library.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraby2.Library.BLL.Services
{
    internal class BookServices: IBookService
    {
        private IBookRepository BookRepository;

        public BookServices(IBookRepository bookRepository)
        {
            BookRepository = bookRepository;
        }

        public void AddBook(BookDTO item)
        {
            BookRepository.AddBook(item.MapBookDtoToEntity());
        }

        public void DeleteBook(int code)
        {
            BookRepository.DeleteBook(code);
        }

        public List<BookDTO> GetAllBooks()
        {

            return BookRepository.GetAllBooks().MapBookListEntityToDto();

        }

        public BookDTO SearchBook(int code)
        {
            return BookRepository.SearchBook(code).MapBookEntityToDto();
        }

        public void ChangeBook(int id, string name, int count, string author)
        {
            BookRepository.ChangeBook(id, name, count, author);
        }
    }
}

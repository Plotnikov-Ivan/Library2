using Libraby2.Library.DAL.Entities;
using Libraby2.Library.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Libraby2.Library.DAL.Repositories
{
    internal class BookRepository : IBookRepository
    {


        private List<BookEntity> books = new List<BookEntity>();

        public List<BookEntity> GetAllBooks()
        {
            return books;
        }

        public BookEntity SearchBook(int code)
        {
            foreach (var item in books)
            {
                if (code == item.id)
                {
                    return item;
                }
            }
            return null;
        }

        public void AddBook(BookEntity book)
        {
            foreach (var item in books)
            {
                if (item.id == book.id)
                {
                    throw new Exception("код книги совпадает");
                }
            }
            books.Add(book);
        }

        public void DeleteBook(int code)
        {
            foreach (var item in books)
            {
                if (code == item.id)
                {
                    books.Remove(item);
                }
            }
        }

        public void ChangeBook(int id, string name, int count, string author)
        {
            foreach (var item in books)
            {
                if (id == item.id)
                {

                        item.name = name;
                        item.count = count;
                        item.author = author;
                }
            }

        }
    }
}
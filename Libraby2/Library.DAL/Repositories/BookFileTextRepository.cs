using Libraby2.Library.DAL.Entities;
using Libraby2.Library.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraby2.Library.DAL.Repositories
{
    public class BookFileTextRepository : IBookRepository
    {
        public void AddBook(BookEntity item)
        {
            List<BookEntity> bookEntities = GetAllBooks();
            foreach (var curr in bookEntities)
            {
                if (curr.id == item.id)
                {
                    throw new Exception("код книги должен отличаться");
                }
            }
            using (var fileWriter = new StreamWriter("libraryBook.txt", true))
            {
                fileWriter.WriteLine(item.id);
                fileWriter.WriteLine(item.author);
                fileWriter.WriteLine(item.genre);
                fileWriter.WriteLine(item.name);
                fileWriter.WriteLine(item.publisher);
                fileWriter.WriteLine(item.year);
            }
        }

        public void DeleteBook(int code)
        {

            List<BookEntity> bookEntities = GetAllBooks();

            for (int i = 0; i < bookEntities.Count; i++)
            {
                if (bookEntities[i].id == code)
                {
                    BookEntity bookEntity = bookEntities[i];
                    bookEntities.Remove(bookEntity);
                }
            }
            using (var fileWriter = new StreamWriter("libraryBook.txt", false))
            {
                for (int i = 0; i < bookEntities.Count; i++)
                {
                    fileWriter.WriteLine(bookEntities[i].id);
                    fileWriter.WriteLine(bookEntities[i].author);
                    fileWriter.WriteLine(bookEntities[i].genre);
                    fileWriter.WriteLine(bookEntities[i].name);
                    fileWriter.WriteLine(bookEntities[i].publisher);
                    fileWriter.WriteLine(bookEntities[i].year);
                }
            }

        }

        public void ChangeBook(int id, string name, int count, string author)
        {
            List<BookEntity> bookEntities = GetAllBooks();
            foreach (var curr in bookEntities)
            {
                if (curr.id == id)
                {
                    curr.publisher = author;
                    curr.name = name;
                    curr.count = count;
                }
            }
        }

        public List<BookEntity> GetAllBooks()
        {
            using (var fileReader = new StreamReader("libraryBook.txt"))
            {
                List<BookEntity> bookEntities = new List<BookEntity>();
                while (!fileReader.EndOfStream)
                {
                    BookEntity currentBook = new BookEntity();

                    currentBook.id = Convert.ToInt32(fileReader.ReadLine());
                    currentBook.author = fileReader.ReadLine();
                    currentBook.genre = fileReader.ReadLine();
                    currentBook.name = fileReader.ReadLine();
                    currentBook.publisher = fileReader.ReadLine();
                    currentBook.year = Convert.ToInt32(fileReader.ReadLine());

                    bookEntities.Add(currentBook);
                }
                return bookEntities;
            }
        }

        public BookEntity SearchBook(int code)
        {
            List<BookEntity> bookEntities = GetAllBooks();

            for (int i = 0; i < bookEntities.Count; i++)
            {
                if (bookEntities[i].id == code)
                {
                    return bookEntities[i];
                }
            }
            return null;
        }
    }
}

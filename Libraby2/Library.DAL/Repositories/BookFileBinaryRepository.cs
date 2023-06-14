using System.Text;
using Libraby2.Library.DAL.Entities;
using Libraby2.Library.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraby2.Library.DAL.Repositories
{
   
    public class BookFileBinaryRepository : IBookRepository
    {
 
        public void AddBook(BookEntity item)
        {
            List<BookEntity> bookEntities = GetAllBooks();
            foreach (var curr in bookEntities)
            {
                if (curr.id == item.id)
                {
                    Console.WriteLine("ID книги не должен совпадать! ");
                }
            }
            using (BinaryWriter binaryWriter = new BinaryWriter(new FileStream(@"libraryBookBin.bin", FileMode.Append), Encoding.GetEncoding(1251)))
            {
                binaryWriter.Write(item.id);
                binaryWriter.Write(item.count);
                binaryWriter.Write(item.author);
                binaryWriter.Write(item.genre);
                binaryWriter.Write(item.name);
                binaryWriter.Write(item.publisher);
                binaryWriter.Write(item.year);
            }
            Console.WriteLine("\n Книга добавлена! ");
        }

        public void DeleteBook(int code)
        {
            List<BookEntity> bookEntities = GetAllBooks();

            //for (int i = 0; i < bookEntities.Count; i++)
            //{
            //    if (bookEntities[i].id == code)
            //    {
            //        BookEntity bookEntity = bookEntities[i];
            //        bookEntities.Remove(bookEntity);
            //    }
            //}

            foreach (BookEntity curr in bookEntities)
            {
                if (curr.id == code)
                {
                    bookEntities.Remove(curr);
                    break;
                }
            }
            using (BinaryWriter binaryWriter = new BinaryWriter(new FileStream(@"libraryBookBin.bin", FileMode.Create), Encoding.GetEncoding(1251)))
            {
                for (int i = 0; i < bookEntities.Count; i++)
                {
                    binaryWriter.Write(bookEntities[i].id);
                    binaryWriter.Write(bookEntities[i].count);
                    binaryWriter.Write(bookEntities[i].author);
                    binaryWriter.Write(bookEntities[i].genre);
                    binaryWriter.Write(bookEntities[i].name);
                    binaryWriter.Write(bookEntities[i].publisher);
                    binaryWriter.Write(bookEntities[i].year);
                }
            }
            Console.WriteLine("\n Книга удалена! ");
        }


        public void ChangeBook(int id, string name, int count, string author)
        {
            List<BookEntity> bookEntities = GetAllBooks();
            foreach (var curr in bookEntities)
            {
                if (curr.id == id)
                {
                    curr.author = author;
                    curr.name = name;
                    curr.count = count;                  
                }
            }
            using (BinaryWriter binaryWriter = new BinaryWriter(new FileStream(@"libraryBookBin.bin", FileMode.OpenOrCreate), Encoding.GetEncoding(1251)))
            {
                for (int i = 0; i < bookEntities.Count; i++)
                {
                    binaryWriter.Write(bookEntities[i].id);
                    binaryWriter.Write(bookEntities[i].count);
                    binaryWriter.Write(bookEntities[i].author);
                    binaryWriter.Write(bookEntities[i].genre);
                    binaryWriter.Write(bookEntities[i].name);
                    binaryWriter.Write(bookEntities[i].publisher);
                    binaryWriter.Write(bookEntities[i].year);
                }
            }
            Console.WriteLine("\n Книга изменена! ");
        }


        public List<BookEntity> GetAllBooks()
        {
            List<BookEntity> bookEntities = new List<BookEntity>();

            using (BinaryReader binaryReader = new BinaryReader(new FileStream(@"libraryBookBin.bin", FileMode.Open), Encoding.GetEncoding(1251)))
            {
                while (binaryReader.PeekChar() > -1)
                {
                    BookEntity currentBook = new BookEntity();

                    currentBook.id = binaryReader.ReadInt32();
                    currentBook.count = binaryReader.ReadInt32();
                    currentBook.author = binaryReader.ReadString();
                    currentBook.genre = binaryReader.ReadString();
                    currentBook.name = binaryReader.ReadString();
                    currentBook.publisher = binaryReader.ReadString();
                    currentBook.year = binaryReader.ReadInt32();

                    bookEntities.Add(currentBook);
                }
            }

            return bookEntities;
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

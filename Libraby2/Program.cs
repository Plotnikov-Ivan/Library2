// See https://aka.ms/new-console-template for more information
using Libraby2.Library.BLL.Services;
using Libraby2.Library.DAL.Repositories;
using Libraby2.Library.WEB.Controllers;
using Libraby2.Library.WEB.Models;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
BookController bookController = new BookController(new BookServices(new BookFileBinaryRepository())); ;

string cmd;
string ans;
string name, author, genre, publ;
int id, count, year;

while (true)
{

    cmd = Console.ReadLine();
    switch (cmd)
    {
        case "-help":    
         Console.WriteLine("Все возможные команды для этой программы: \n" +
         "-input  --  Добавить новую книгу/журнал \n" + "-delete  --  Удаление книги/журнала по ID \n" +
         "-change  --  Изменить данные о книге/журнале \n" + "-search  --  Поиск книги/журнала по названию \n" +
         "-end  --  Выход" + "\n -showb  --  Показать все книги");
        break;

        case "-input":   
         Console.WriteLine("Вы желаете добавить книгу или журнал?");
         ans = Console.ReadLine();

         if (ans == "Книгу" || ans == "книгу")
         {
            Console.WriteLine("Введите ID книги:");
            id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите Название книги:");
            name = Console.ReadLine();

            Console.WriteLine("Введите количество книг:");
            count = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите автора книги:");
            author = Console.ReadLine();

            Console.WriteLine("Введите жанр книги:");
            genre = Console.ReadLine();

            Console.WriteLine("Введите год издания книги:");
            year = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите издательство книги:");
            publ = Console.ReadLine();


            BookModel bookModel = new BookModel(id, name, count, author, genre, year, publ);

            bookController.AddBook(bookModel);

            break;

         }
        break;

        case "-delete":
    
        Console.WriteLine("Вы желаете удалить книгу или журнал?");
        ans = Console.ReadLine();

        if (ans == "Книгу" || ans == "книгу")
        {
            int iddel;
            Console.WriteLine("Введите ID книги:");
            iddel = Convert.ToInt32(Console.ReadLine());
            bookController.DeleteBook(iddel);
            break;
        }
        break;

        case "-showb":
            List<BookModel> bookModels = bookController.GetAllBooks();
            foreach (var item in bookModels)
            {
                Console.WriteLine("Название: " + item.name + '\n' + "Код: " + item.id + '\n' + "Автор: " + item.author);
                Console.WriteLine("-------------------------------------------------------------");
            }
            break;


        case "-search":
            BookModel bookfind = new BookModel();
            Console.WriteLine("Вы желаете найти книгу или журнал?");
            ans = Console.ReadLine();
            if (ans == "Книгу" || ans == "книгу")
            {
                int idser;
                Console.WriteLine("Введите ID книги:");
                idser = Convert.ToInt32(Console.ReadLine());
                bookfind = bookController.SearchBook(idser);
                Console.WriteLine("Название: " + bookfind.name + '\n' + "Код: " + bookfind.id + '\n' + "Автор: " + bookfind.author);
                Console.WriteLine("-------------------------------------------------------------");
                break;
            }
            break;

        case "-change":
            BookModel bookch = new BookModel();
            string NewParam;
            Console.WriteLine("Вы желаете изменить книгу или журнал?");
            ans = Console.ReadLine();
            if (ans == "Книгу" || ans == "книгу")
            {
                int idch;
                Console.WriteLine("Введите ID книги:");
                idch = Convert.ToInt32(Console.ReadLine());
                bookch = bookController.SearchBook(idch);
                Console.WriteLine("\n 1 --  Изменить имя" + "\n 2 -- Изменить количество" + "\n 3 -- Изменить автора");
                if ( Console.ReadLine() == "1")
                {
                    Console.WriteLine("\n Введите новое имя");
                    NewParam = Console.ReadLine();
                    bookController.ChangeBook(idch, NewParam, bookch.count, bookch.author);
                    Console.WriteLine("Название: " + NewParam + '\n' + "Код: " + bookch.id + '\n' + "Автор: " + bookch.author + "Количество: " + bookch.count);
                    Console.WriteLine("-------------------------------------------------------------");
                }
                if (Console.ReadLine() == "2")
                {
                    int iNewParam;
                    Console.WriteLine("\n Введите количество");
                    iNewParam = Convert.ToInt32(Console.ReadLine());
                    bookController.ChangeBook(idch, bookch.name, iNewParam, bookch.author);
                    Console.WriteLine("Название: " + bookch.name + '\n' + "Код: " + bookch.id + '\n' + "Автор: " + bookch.author + '\n' 
                        + "Количество: " + iNewParam);
                    Console.WriteLine("-------------------------------------------------------------");
                }
                if (Console.ReadLine() == "3")
                {
                    Console.WriteLine("\n Введите количество");
                    NewParam = Console.ReadLine();
                    bookController.ChangeBook(idch, bookch.name, bookch.count, NewParam);
                    Console.WriteLine("Название: " + bookch.name + '\n' + "Код: " + bookch.id + '\n' + "Автор: " + NewParam + '\n' 
                        + "Количество: " + bookch.count);
                    Console.WriteLine("-------------------------------------------------------------");
                }

                break;
            }
            break;

        case "-end":
            Environment.Exit(0);
            break;

    } 


}
// See https://aka.ms/new-console-template for more information
using Libraby2.Library.BLL.Services;
using Libraby2.Library.DAL.Repositories;
using Libraby2.Library.WEB.Controllers;
using Libraby2.Library.WEB.Models;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
Console.OutputEncoding = System.Text.Encoding.UTF8;
BookController bookController = new BookController(new BookServices(new BookFileBinaryRepository()));
JournalController jrController = new JournalController(new JournalServices(new JournalDataBaseRepository())); 

string cmd;
string ans;
string name, author, genre, publ, freq;
int id, count, year, number;

while (true)
{

    cmd = Console.ReadLine();
    switch (cmd)
    {
        case "-help":    
         Console.WriteLine("Все возможные команды для этой программы: \n" +
         "-input  --  Добавить новую книгу/журнал \n" + "-delete  --  Удаление книги/журнала по ID \n" +
         "-change  --  Изменить данные о книге/журнале \n" + "-search  --  Поиск книги/журнала по названию \n" +
         "-end  --  Выход" + "\n-showb  --  Показать все книги" + "\n-showj  --  Показать все журналы");
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
         if (ans == "Журнал" || ans == "журнал")
         {
            Console.WriteLine("Введите ID журнала:");
            id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите Название журнала:");
            name = Console.ReadLine();

            Console.WriteLine("Введите количество журналов:");
            count = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите периодичность журнала:");
            freq = Console.ReadLine();

            Console.WriteLine("Введите год издания журнала:");
            year = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите издательство журнала:");
            publ = Console.ReadLine();

            Console.WriteLine("Введите номер журнала:");
            number = Convert.ToInt32(Console.ReadLine());



            JournalModel jrModel = new JournalModel(id, name, freq, count, year, publ, number);

            jrController.AddJournal(jrModel);

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
        if (ans == "Журнал" || ans == "журнал")
            {
              int iddel;
              Console.WriteLine("Введите ID журнала:");
              iddel = Convert.ToInt32(Console.ReadLine());
              jrController.DeleteJournal(iddel);
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

        case "-showj":
            List<JournalModel> jrModels = jrController.GetAllJournals();
            foreach (var item in jrModels)
            {
                Console.WriteLine("Название: " + item.name + '\n' + "Код: " + item.id + '\n' + "Автор: " + item.year);
                Console.WriteLine("-------------------------------------------------------------");
            }
            break;


        case "-search":
            BookModel bookfind = new BookModel();
            JournalModel jrfind = new JournalModel();
            Console.WriteLine("Вы желаете найти книгу или журнал?");
            ans = Console.ReadLine();
            if (ans == "Книгу" || ans == "книгу")
            {
                int idser;
                Console.WriteLine("Введите ID книги:");
                idser = Convert.ToInt32(Console.ReadLine());
                bookfind = bookController.SearchBook(idser);
                if (bookfind != null)
                {
                    Console.WriteLine("Название: " + bookfind.name + '\n' + "Код: " + bookfind.id + '\n' + "Автор: " + bookfind.author);
                    Console.WriteLine("-------------------------------------------------------------");
                }
                break;
            }
            if (ans == "Журнал" || ans == "журнал")
            {
                int idser;
                Console.WriteLine("Введите ID журнала:");
                idser = Convert.ToInt32(Console.ReadLine());
                jrfind = jrController.SearchJournal(idser);
                if (jrfind != null)
                {
                    Console.WriteLine("Название: " + jrfind.name + '\n' + "Код: " + jrfind.id + '\n' + "Автор: " + jrfind.year);
                    Console.WriteLine("-------------------------------------------------------------");
                }
                break;
            }
            break;

        case "-change":
            BookModel bookch = new BookModel();
            JournalModel jrch= new JournalModel();
            string NewParam;
            int iNewParam;
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
            if (ans == "Журнал" || ans == "журнал")
            {
                int idch;
                Console.WriteLine("Введите ID журнала:");
                idch = Convert.ToInt32(Console.ReadLine());
                jrch = jrController.SearchJournal(idch);
                Console.WriteLine("\n 1 --  Изменить имя" + "\n 2 -- Изменить количество" + "\n 3 -- Изменить номер журнала");
                int answer = Convert.ToInt32(Console.ReadLine());
                if (answer == 1)
                {
                    Console.WriteLine("\n Введите новое имя");
                    NewParam = Console.ReadLine();
                    jrController.ChangeJournal(idch, NewParam, jrch.count, jrch.number);
                    Console.WriteLine("Название: " + NewParam + '\n' + "Код: " + jrch.id + '\n' + "Номер журнала: " + jrch.number + "Количество: " + jrch.count);
                    Console.WriteLine("-------------------------------------------------------------");
                }
                if (answer == 2)
                {
                    Console.WriteLine("\n Введите количество");
                    iNewParam = Convert.ToInt32(Console.ReadLine());
                    jrController.ChangeJournal(idch, jrch.name, iNewParam, jrch.number);
                    Console.WriteLine("Название: " + jrch.name + '\n' + "Код: " + jrch.id + '\n' + "Номер журнала: " + jrch.number + '\n'
                        + "Количество: " + iNewParam);
                    Console.WriteLine("-------------------------------------------------------------");
                }
                if (answer == 3)
                {
                    Console.WriteLine("\n Введите количество");
                    iNewParam = Convert.ToInt32(Console.ReadLine());
                    jrController.ChangeJournal(idch, jrch.name, jrch.count, iNewParam);
                    Console.WriteLine("Название: " + jrch.name + '\n' + "Код: " + jrch.id + '\n' + "Номер журнала: " + iNewParam + '\n'
                        + "Количество: " + jrch.count);
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
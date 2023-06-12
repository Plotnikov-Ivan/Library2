using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraby2.Library.BLL.DTO
{
    public class BookDTO
    {

        public BookDTO() 
        { 
        
        }    
        public BookDTO(int new_id, string new_name, int new_count, string new_author, string new_genre, int new_year, string new_publisher)
        {
            id = new_id;
            year = new_year;
            name = new_name;
            count = new_count;
            author = new_author;
            genre = new_genre;
            publisher = new_publisher;
        }

        public int id { get; set; }

        public string name { get; set; }

        public int count { get; set; }

        public string author { get; set; }

        public string genre { get; set; }

        public int year { get; set; }

        public string publisher { get; set; }

    }
}

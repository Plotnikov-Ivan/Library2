using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraby2.Library.WEB.Models
{
    public class JournalModel
    { 
        public JournalModel() { }
        public JournalModel(int new_id, string new_name, string new_freq, int new_count, int new_year, string new_publisher, int new_number)
        {
            id = new_id;
            year = new_year;
            count = new_count;
            name = new_name;
            freq = new_freq;
            number = new_number;
            publisher = new_publisher;
        }

        public int id { get; set; }
        public int year { get; set; }
        public string name { get; set; }
        public int count { get; set; }

        public string freq { get; set; }

        public int number { get; set; }

        public string publisher { get; set; }
    }
}

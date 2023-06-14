using Libraby2.Library.DAL.Entities;
using Libraby2.Library.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Libraby2.Library.DAL.Repositories
{
    public class JournalRepository
    {
        private List<JournalEntity> journals = new List<JournalEntity>();


        public List<JournalEntity> GetAllJournals()
        {
            return journals;
        }

        public JournalEntity SearchJournal(int id)
        {
            foreach (var item in journals)
            {
                if (id == item.id)
                {
                    return item;
                }
            }
            return null;
        }

        public void AddJournal(JournalEntity jr)
        {
            foreach (var item in journals)
            {
                if (item.id == jr.id)
                {
                    throw new Exception("код журнала должен отличаться");
                }
            }
            journals.Add(jr);
        }

        public void DeleteJournal(int id)
        {
            foreach (var item in journals)
            {
                if (id == item.id)
                {
                    journals.Remove(item);
                }
            }
        }

        public void ChangeJournal(int id, string name, int count, int number)
        {
            foreach (var item in journals)
            {
                if (id == item.id)
                {

                    item.name = name;
                    item.count = count;
                    item.number = number;
                }
            }

        }
    }
}

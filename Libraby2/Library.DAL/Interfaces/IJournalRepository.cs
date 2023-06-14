using Libraby2.Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraby2.Library.DAL.Interfaces
{
    public interface IJournalRepository
    {
        List<JournalEntity> GetAllJournals();
        JournalEntity SearchJournal(int code);
        void AddJournal(JournalEntity item);
        void DeleteJournal(int code);
        void ChangeJournal(int id, string name, int count, int number);
    }
}

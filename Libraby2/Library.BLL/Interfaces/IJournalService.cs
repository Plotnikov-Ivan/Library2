using System;
using Libraby2.Library.BLL.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraby2.Library.BLL.Interfaces
{
    public interface IJournalService
    {
        List<JournalDTO> GetAllJournals();
        JournalDTO SearchJournal(int code);
        void AddJournal(JournalDTO item);
        void DeleteJournal(int code);
        void ChangeJournal(int id, string name, int count, int number);
    }
}

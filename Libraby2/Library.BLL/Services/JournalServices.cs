using Libraby2.Library.BLL.DTO;
using Libraby2.Library.BLL.Interfaces;
using Libraby2.Library.BLL.Mappers;
using Libraby2.Library.DAL.Interfaces;
using Libraby2.Library.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libraby2.Library.DAL.Repositories;

namespace Libraby2.Library.BLL.Services
{
    public class JournalServices: IJournalService
    {
        private IJournalRepository JournalRepository;

        public JournalServices(IJournalRepository _JournalRepository)
        {
            JournalRepository = _JournalRepository;
        }

        public void AddJournal(JournalDTO item)
        {
            JournalRepository.AddJournal(item.MapJournalDtoToEntity());
        }

        public void DeleteJournal(int code)
        {
            JournalRepository.DeleteJournal(code);
        }

        public List<JournalDTO> GetAllJournals()
        {
            return JournalRepository.GetAllJournals().MapJournalListEntityToDto();
        }

        public JournalDTO SearchJournal(int code)
        {
            return JournalRepository.SearchJournal(code).MapJournalEntityToDto();
        }

        public void ChangeJournal(int id, string name, int count, int number)
        {
            JournalRepository.ChangeJournal(id, name, count, number);
        }
    }
}

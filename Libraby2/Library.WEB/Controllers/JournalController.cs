using System;
using Libraby2.Library.BLL.Interfaces;
using Libraby2.Library.BLL.Mappers;
using Libraby2.Library.WEB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraby2.Library.WEB.Controllers
{
    internal class JournalController
    {
        private IJournalService journalService;
        public JournalController(IJournalService _JournalService)
        {
            journalService = _JournalService;
        }
        public void AddJournal(JournalModel jrModel)
        {
            journalService.AddJournal(jrModel.MapJournalModelToDto());
        }
        public List<JournalModel> GetAllJournals()
        {
            return journalService.GetAllJournals().MapJournalListDtoToModel();
        }

        public JournalModel SearchJournal(int id)
        {
            return journalService.SearchJournal(id).MapJournalDtoToModel();
        }
        public void DeleteJournal(int id)
        {
            journalService.DeleteJournal(id);
        }

        public void ChangeJournal(int id, string name, int count, int number)
        {
            journalService.ChangeJournal(id, name, count, number);
        }
    }
}

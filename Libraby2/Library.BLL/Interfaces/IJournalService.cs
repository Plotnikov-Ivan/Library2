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
        List<JournalDTO> GetAllMagazines();
        JournalDTO SearchMagazine(int code);
        void AddMagazine(JournalDTO item);
        void DeleteMagazine(int code);
    }
}

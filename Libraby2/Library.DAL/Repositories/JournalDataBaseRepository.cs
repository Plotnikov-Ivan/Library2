using Libraby2.Library.DAL.Entities;
using Libraby2.Library.DAL.Interfaces;
using System.Text;
using Libraby2.Library.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;


namespace Libraby2.Library.DAL.Repositories
{
    public class JournalDataBaseRepository : IJournalRepository
    {
        public void AddJournal(JournalEntity item)
        {           
            using (JournalDataBase db = new JournalDataBase())
            {
                db.Journals.AddRange(item);
                db.SaveChanges();
            }
        }

        public void DeleteJournal(int code) 
        {
            List<JournalEntity> JrEntities = GetAllJournals();
            using (JournalDataBase db = new JournalDataBase())
            {               
                foreach (var curr in JrEntities)
                {
                    if (code == curr.id)
                    {
                        db.Journals.Remove(curr);
                        db.SaveChanges();
                    }
                }
            }
        }

        public List<JournalEntity> GetAllJournals() 
        {           
            using (JournalDataBase db = new JournalDataBase())
            {
                return db.Journals.ToList();
            }
        }

        public JournalEntity SearchJournal(int code) 
        {
            using (JournalDataBase db = new JournalDataBase())
            {
                    if (db.Journals.Find(code) != null)
                    {
                        return db.Journals.Find(code);
                    }
               
            }
            return null;
        }

        public void ChangeJournal(int id, string name, int count, int number) 
        {
            using (JournalDataBase db = new JournalDataBase())
            {
                JournalEntity JrEntity = db.Journals.Find(id);
                if (JrEntity != null)
                {
                    JrEntity.name = name;
                    JrEntity.count = count;
                    JrEntity.number = number;
                    db.SaveChanges();
                }
            }
        }

    }
    }
